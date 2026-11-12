using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AmaanWRT
{
[CompilerGenerated]
internal sealed class Fnv1aHash
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 32)]
	private struct DataMarker
	{
	}

	private static readonly DataMarker field_646/* Not supported: data(01 23 45 67 89 AB CD EF FE DC BA 98 76 54 32 10 89 AB CD EF 01 23 45 67 23 45 67 89 AB CD EF 01) */;

	internal static uint method_647(string P_0)
	{
		uint num = default;
		if (P_0 != null)
		{
			num = 2166136261u;
			for (int i = 0; i < P_0.Length; i++)
			{
				num = (P_0[i] ^ num) * 16777619;
			}
		}
		return num;
	}
}
}
