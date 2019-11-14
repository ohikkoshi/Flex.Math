using System.Runtime.CompilerServices;
#if !UNITY_2017_1_OR_NEWER
using Vector3 = System.Numerics.Vector3;
#else
using Vector3 = UnityEngine.Vector3;
#endif

namespace Flex.Math
{
	public sealed class CatmullRom
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sample(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			var a = 2f * p1;
			var b = p2 - p0;
			var c = (2f * p0) - (5f * p1) + (4f * p2) - p3;
			var d = -p0 + (3f * p1) - (3f * p2) + p3;

			return (0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t)));
		}
	}
}
