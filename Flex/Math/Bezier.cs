using System.Runtime.CompilerServices;
#if !UNITY_2017_1_OR_NEWER
using Vector3 = System.Numerics.Vector3;
#else
using Vector3 = UnityEngine.Vector3;
#endif

namespace Flex.Math
{
	public sealed class Bezier
	{
#if !UNITY_2017_1_OR_NEWER
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sample(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			var v0 = (1f - t) * (1f - t) * (1f - t);
			var v1 = 3f * t * (1f - t) * (1f - t);
			var v2 = 3f * t * t * (1f - t);
			var v3 = t * t * t;
			var x = (v0 * p0.X) + (v1 * p1.X) + (v2 * p2.X) + (v3 * p3.X);
			var y = (v0 * p0.Y) + (v1 * p1.Y) + (v2 * p2.Y) + (v3 * p3.Y);
			var z = (v0 * p0.Z) + (v1 * p1.Z) + (v2 * p2.Z) + (v3 * p3.Z);

			return new Vec3(x, y, z);
		}
#else
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Sample(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			var v0 = (1f - t) * (1f - t) * (1f - t);
			var v1 = 3f * t * (1f - t) * (1f - t);
			var v2 = 3f * t * t * (1f - t);
			var v3 = t * t * t;
			var x = (v0 * p0.x) + (v1 * p1.x) + (v2 * p2.x) + (v3 * p3.x);
			var y = (v0 * p0.y) + (v1 * p1.y) + (v2 * p2.y) + (v3 * p3.y);
			var z = (v0 * p0.z) + (v1 * p1.z) + (v2 * p2.z) + (v3 * p3.z);

			return new Vector3(x, y, z);
		}
#endif
	}
}
