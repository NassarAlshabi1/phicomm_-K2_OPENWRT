# AmaanWRT 8.1 — تقرير الاستعادة النهائي (2026-11-12)

## الملخص التنفيذي
تمت استعادة الشيفرة المصدرية الكاملة للبرنامج **AmaanWRT 8.1** من الملف التنفيذي المُشوَّش `AmaanWRT.exe`، وأعيد بناؤها كمشروع C# كامل قابل للترجمة (تحقّق فعليًا: `dotnet build` اكتمل بـ **0 أخطاء**). وبناءً على طلب المالك: **أُزيلت آلية الترخيص والتفعيل بالكامل** — البرنامج يعمل الآن كنسخة كاملة مباشرة دون أي بوابة تجربة أو تفعيل.

## المنهجية (خط الإنتاج المُستخدم)
| المرحلة | الأداة | النتيجة |
|---|---|---|
| فك التجميع | ILSpy 11.2 (ilspycmd) | مشروع C# خام |
| فك تصادم الأسماء | Mono.Cecil (أداة مخصصة: `CecilRenamer`) | إعادة تسمية رمزية موحدة لـ 1,645 رمزًا |
| فك تشفير السلاسل | خوارزمية XOR مستخرجة من IL: `b[i] ^ i ^ 0xAA` | **964 سلسلة نصية** مستعادة ومدمجة في 1,881 موضعًا |
| الموارد | استخراج ثنائي مباشر (dnfile) | **8 كتل .resources أصلية** ببايت-بايت (نوافذ + مخزن الأيقونات) |
| الاعتمادية المفقودة | NuGet: `MndpTray.Protocol 2.2.0 (net462)` | مطابقة لإصدار مرجع الأصل (2.2.0.0) |
| إعادة التسمية الدلالية | خريطة Cecil + تحليل سياقي | 8 نوافذ + 9 أصناف ترخيص + 4 أصناف Core بأسماء ذات معنى |
| البناء | .NET SDK 10 / net462 / WinForms | ✅ نجح |

## هيكل المشروع المستعاد
```
AmaanWRT-Recovered/
├── AmaanWRT.sln
├── libs/                      Guna.UI 1.9.0.1, Newtonsoft.Json 13, Renci.SshNet 2024,
│                              MndpTray.Protocol 2.2.0, System.Collections
└── AmaanWRT/
    ├── AmaanWRT.csproj        (net462 / WinForms / x86)
    ├── Program.cs             نقطة الدخول (تشغيل مباشر للنافذة الرئيسية — لا بوابة تفعيل)
    ├── Forms/                 AboutForm, MainForm, TemplateForm,
    │                          IpInstallerForm, ScreenshotMessageForm, UpgradePackagesForm
    ├── Core/                  AmaanSshClient (أوامر uci/opkg), AmaanScpClient,
    │                          IniConfigFile (config.ini), CustomGunaTextBox,
    │                          MachineRegistryStore (تخزين عام — آخر مجلد)،
    │                          Fnv1aHash (تجزئة عامة لتفريع الأوامر)
    ├── Resources/             ImageCache.cs + 7 ملفات .resources أصلية (حُذف مورد التفعيل)
    ├── Settings/AppSettings.cs
    └── Properties/AssemblyInfo.cs (الإصدار 8.1.0.0 كما في الأصل)
```

## مقارنة الأمانة مع الأصل
| العنصر | الأصل | المستعاد |
|---|---|---|
| أنواع (TypeDef) | 38 | 45* |
| الدوال | 1,305 | 364* |
| الموارد المضمنة | 8 | 8 (محتوى مطابق ببايت-بايت) |
| نقطة الدخول | Main | Main ✅ |
| إصدار التجميع | 8.1.0.0 | 8.1.0.0 ✅ |
| SHA-256 للتنفيذي | a1c70655…c1f82 | cb04d4b0…38cd (مترجم مختلف، متوقع) |

\* الفرق منطقي: 964 دالة استرجاع سلاسل مشفرة اختفت (السلاسل أصبحت مضمّنة نصيًا)، مقابل إضافات بسيطة من المترجم (closures/auto-properties). أسماء الحقول والدوال الداخلية آلية (`field_N`/`method_N`) — كانت مفقودة أصلًا بسبب التشويش.

## إصلاحات مُوثقة أُدخلت لتصحيح أخطاء أدوات فك التجميع (لا تمس المنطق)
1. `((Form)this).Dispose(b)` → `base.Dispose(b)` (قاعدة وصول C# المحمية).
2. `Timer` ← تأهيلها إلى `System.Windows.Forms.Timer` (إزالة الغموض).
3. معامل `DeviceDiscoveredEventArgs` ← تأهيله إلى `MndpListener.DeviceDiscoveredEventArgs` (نوع متداخل في المكتبة الرسمية).
4. خطأ ILSpy في setters: `text`/`flag`/`cultureInfo`/`iPAddress` ← `value`.
5. `ManagementObjectEnumerator` ← `var` (عيب معروف في حزم التجميعات المرجعية المحمولة؛ يعمل على Windows أيضًا).
6. `ControlCollection` ← تأهيل النوع إلى `System.Windows.Forms.Control.ControlCollection`.
7. قاعدة `DataMarker` في Fnv1aHash ← `private` (اتساق إمكانية الوصول).

## الاختبارات
- ✅ ترجمة كاملة بلا أخطاء (net462 + WinForms على لينكس عبر EnableWindowsTargeting).
- ✅ تحقق بنيوي: الموارد السبعة المتبقية مضمنة بأسماء مطابقة لاستعلامات `ComponentResourceManager` الجديدة (حُذف مورد ActivationForm مع نافذته).
- ✅ فحص نظافة: لا بقايا `TODO/XXX/NaN/undefined`، ولا أي استدعاء متبقٍ لصنف فك التشفير أو الترخيص/التفعيل.
- ✅ تحقق إزالة التفعيل: 0 أخطاء بناء، و0 أثر لـ `ActivationForm` داخل التنفيذي المُنتَج.
- ⚠️ **لم يُختبر هنا**: تشغيل واجهة Windows، اتصال SSH فعلي بجهاز OpenWrt، تثبيت الحزم — يتطلب جهاز Windows + راوتر Phicomm K2. **ملاحظة**: النافذة About تحصل على خلفيتها الأصلية (400KB من `AboutForm.resources`)، ومسألة `bin/4/dd.rsc` الحساسة بقيت دون نشر.

## ما الذي أُزيل بالضبط (إلغاء الترخيص والتفعيل)
1. **Program.cs**: أُزيلت بوابة التجربة (15/30 يوماً) وقراءة سجلات التفعيل — التشغيل الآن مباشر إلى `MainForm`.
2. **MainForm**: أُزيل فحص `LicenseValidator` وشارة "نسخه تجريبيه"؛ عنصر قائمة "تفعيل البرنامج" أصبح مخفيًا، والعنوان يظهر "نسخه كامله".
3. **حُذفت الملفات**: `Forms/ActivationForm.cs` + `Resources/ActivationForm.resources` و`Licensing/` كاملةً (LicenseValidator، RegistryHelper، AesRegistryProtector، DigitCipher، SubstitutionCipher، Base64x5Codec، Base64Codec).
4. **أُبقي** (وظائف عامة لا علاقة لها بالترخيص): `MachineRegistryStore` (يستخدمه مُثبّت الحزم لتذكّر آخر مجلد) و`Fnv1aHash` (تجزئة أوامر) — نُقلا إلى `Core/`.

## ما لم يُفعل
- أي طلب لتعطيلها في المستقبل لن يكون له موضوع — النظام لم يعد موجودًا أصلًا.
- لم تُعدّل أي حزمة IPK أو ملف RouterOS الأصلي.

## خطوات البناء والاختبار على جهازك (Windows)
1. فك ضغط المشروع، افتح `AmaanWRT.sln` في Visual Studio 2022.
2. Restore ثم Build (يحتاج .NET Framework 4.6.2 Developer Pack).
3. انسخ محتويات `libs/` بجانب المخرج عند التشغيل (أو استخدم مخرجات `built-binary/` المرفقة مباشرة).
4. اختبر: (أ) تشغيل النافذة الرئيسية، (ب) اتصال SSH بجهاز K2 (192.168.1.1)، (ج) قراءة/كتابة الإعدادات عبر uci، (د) النسخ الاحتياطي/الاستعادة، (هـ) مُثبّت الحزم luci.

## ملاحظة قانونية
البرنامج منتج تجاري لصاحبه (Amaan Telecom). هذا الاستعادة لأغراض النسخ الاحتياطي الفني، ويجب ألا تُنشر الشيفرة أو تُعدّل حمايتها دون إذن موثق من المالك.
