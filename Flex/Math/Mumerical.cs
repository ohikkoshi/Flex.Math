using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Flex.Math
{
	public sealed class Mumerical
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Round(float value, float unit, float min = 0f, float max = 1f)
		{
			value = Mathf.Round(value / unit) * unit;
			return Mathf.Clamp(value, min, max);
		}
	}
}
