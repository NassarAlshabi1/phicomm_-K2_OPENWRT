using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace AmaanWRT
{
    /// <summary>
    /// الخطوط الموحّدة للواجهة العربية.
    /// يُحَدِّد عند الإقلاع أفضل خط عربي متوفر على النظام (Segoe UI أولاً —
    /// أفضل خط واجهات عربي مضمّن في ويندوز منذ ويندوز 7، ويتولى النظام
    /// الربط البديل تلقائياً إن لم تتوفر حروفه العربية)، مع خط أحادي المسافة
    /// لعرض مخرجات الطرفية (Consolas أو ما يتوفر).
    /// استُبدلت به جميع الاستدعاءات الثابتة ("Tahoma"/"Arial"/"Segoe UI")
    /// لتوحيد الهوية الطباعية العربية في كامل البرنامج.
    /// </summary>
    internal static class UiFonts
    {
        /// <summary>عائلة الخط العربي المعتمدة للواجهة (تُحَل مرة واحدة عند الإقلاع).</summary>
        internal static readonly string ArabicFamily = ResolveArabicFamily();

        /// <summary>عائلة الخط الأحادي المسافة لمخرجات الأوامر.</summary>
        internal static readonly string MonoFamily = ResolveMonoFamily();

        private static string ResolveArabicFamily()
        {
            try
            {
                using (InstalledFontCollection installed = new InstalledFontCollection())
                {
                    HashSet<string> names = new HashSet<string>(
                        installed.Families.Select((FontFamily f) => f.Name),
                        StringComparer.OrdinalIgnoreCase);
                    string[] candidates = new string[2] { "Segoe UI", "Tahoma" };
                    string[] array = candidates;
                    foreach (string candidate in array)
                    {
                        if (names.Contains(candidate))
                        {
                            return candidate;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return "Segoe UI";
        }

        private static string ResolveMonoFamily()
        {
            try
            {
                using (InstalledFontCollection installed = new InstalledFontCollection())
                {
                    HashSet<string> names = new HashSet<string>(
                        installed.Families.Select((FontFamily f) => f.Name),
                        StringComparer.OrdinalIgnoreCase);
                    string[] candidates = new string[3] { "Cascadia Mono", "Consolas", "Courier New" };
                    string[] array = candidates;
                    foreach (string candidate in array)
                    {
                        if (names.Contains(candidate))
                        {
                            return candidate;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return "Consolas";
        }

        internal static Font Create(float size)
        {
            return new Font(ArabicFamily, size);
        }

        internal static Font Create(float size, FontStyle style)
        {
            return new Font(ArabicFamily, size, style);
        }

        internal static Font Create(float size, FontStyle style, GraphicsUnit unit)
        {
            return new Font(ArabicFamily, size, style, unit);
        }

        internal static Font Create(float size, FontStyle style, GraphicsUnit unit, byte gdiCharSet)
        {
            return new Font(ArabicFamily, size, style, unit, gdiCharSet);
        }

        /// <summary>خط أحادي المسافة لعرض مخرجات الأوامر والأطراف.</summary>
        internal static Font CreateMono(float size)
        {
            return new Font(MonoFamily, size);
        }
    }
}
