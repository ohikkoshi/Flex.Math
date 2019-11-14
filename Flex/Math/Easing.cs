using System;
using System.Runtime.CompilerServices;

namespace Flex.Math
{
	public sealed class Easing
	{
		public enum Type
		{
			Linear = 0,
			ExpoOut, ExpoIn, ExpoInOut, ExpoOutIn,
			CircOut, CircIn, CircInOut, CircOutIn,
			QuadOut, QuadIn, QuadInOut, QuadOutIn,
			SineOut, SineIn, SineInOut, SineOutIn,
			CubicOut, CubicIn, CubicInOut, CubicOutIn,
			QuartOut, QuartIn, QuartInOut, QuartOutIn,
			QuintOut, QuintIn, QuintInOut, QuintOutIn,
			ElasticOut, ElasticIn, ElasticInOut, ElasticOutIn,
			BounceOut, BounceIn, BounceInOut, BounceOutIn,
			BackOut, BackIn, BackInOut, BackOutIn
		}

		static readonly Func<float, float, float, float>[] Functions = {
			Linear,
			ExpoOut, ExpoIn, ExpoInOut, ExpoOutIn,
			CircOut, CircIn, CircInOut, CircOutIn,
			QuadOut, QuadIn, QuadInOut, QuadOutIn,
			SineOut, SineIn, SineInOut, SineOutIn,
			CubicOut, CubicIn, CubicInOut, CubicOutIn,
			QuartOut, QuartIn, QuartInOut, QuartOutIn,
			QuintOut, QuintIn, QuintInOut, QuintOutIn,
			ElasticOut, ElasticIn, ElasticInOut, ElasticOutIn,
			BounceOut, BounceIn, BounceInOut, BounceOutIn,
			BackOut, BackIn, BackInOut, BackOutIn
		};

		static readonly float PI = (float)Math.PI;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Lerp(Type type, float t, float min = 0f, float max = 1f)
		{
			return Functions[(int)type](t, min, max);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Linear(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ExpoOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return (max * (-(float)Math.Pow(2f, -10f * t) + 1f)) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ExpoIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * (float)Math.Pow(2f, 10f * (t - 1f)) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ExpoInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * (float)Math.Pow(2f, 10f * (t - 1f)) + min;
			} else {
				return max / 2f * (-(float)Math.Pow(2f, -10f * --t) + 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ExpoOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return ExpoOut(t * 2f, min, max / 2f);
			} else {
				return ExpoIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CircOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * (float)Math.Sqrt(1f - (t = t - 1f) * t) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CircIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return -max * ((float)Math.Sqrt(1f - t * t) - 1f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CircInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return -max / 2f * ((float)Math.Sqrt(1f - t * t) - 1f) + min;
			} else {
				return max / 2f * ((float)Math.Sqrt(1f - (t -= 2f) * t) + 1f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CircOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return CircOut(t * 2f, min, max / 2f);
			} else {
				return CircIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuadOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return -max * t * (t - 2f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuadIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t * t + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuadInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * t * t + min;
			} else {
				return -max / 2f * ((--t) * (t - 2f) - 1f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuadOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return QuadOut(t * 2f, min, max / 2f);
			} else {
				return QuadIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SineOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * (float)Math.Sin(t * (PI / 2f)) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SineIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return -max * (float)Math.Cos(t * (PI / 2f)) + max + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SineInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * ((float)Math.Sin(PI * t / 2f)) + min;
			} else {
				return -max / 2f * ((float)Math.Cos(PI * --t / 2f) - 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SineOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return SineOut(t * 2f, min, max / 2f);
			} else {
				return SineIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CubicOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * ((t = t - 1f) * t * t + 1f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CubicIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t * t * t + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CubicInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * t * t * t + min;
			} else {
				return max / 2f * ((t -= 2f) * t * t + 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CubicOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return CubicOut(t * 2f, min, max / 2f);
			} else {
				return CubicIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuartOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return -max * ((t = t - 1f) * t * t * t - 1f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuartIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t * t * t * t + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuartInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * t * t * t * t + min;
			} else {
				return -max / 2f * ((t -= 2f) * t * t * t - 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuartOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return QuartOut(t * 2f, min, max / 2f);
			} else {
				return QuartIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuintOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * ((t = t - 1f) * t * t * t * t + 1f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuintIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t * t * t * t * t + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuintInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * t * t * t * t * t + min;
			} else {
				return max / 2f * ((t -= 2f) * t * t * t * t + 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float QuintOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return QuintOut(t * 2f, min, max / 2f);
			} else {
				return QuintIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ElasticOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			float p = 0.3f;
			float s = p / 4f;

			return (max * (float)Math.Pow(2f, -10f * t) * (float)Math.Sin((t - s) * (2f * PI) / p) + max + min);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ElasticIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			float p = 0.3f;
			float s = p / 4f;

			return -(max * (float)Math.Pow(2f, 10f * (t -= 1f)) * (float)Math.Sin((t - s) * (2f * PI) / p)) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ElasticInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			float p = (0.3f * 1.5f);
			float s = p / 4f;

			if (t < 1f) {
				return -0.5f * (max * (float)Math.Pow(2f, 10f * (t -= 1f)) * (float)Math.Sin((t - s) * (2f * PI) / p)) + min;
			} else {
				return max * (float)Math.Pow(2f, -10f * (t -= 1f)) * (float)Math.Sin((t - s) * (2f * PI) / p) * 0.5f + max + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ElasticOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return ElasticOut(t * 2f, min, max / 2f);
			} else {
				return ElasticIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BounceOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < (1f / 2.75f)) {
				return max * (7.5625f * t * t) + min;
			} else if (t < (2f / 2.75f)) {
				return max * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f) + min;
			} else if (t < (2.5f / 2.75f)) {
				return max * (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f) + min;
			} else {
				return max * (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BounceIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max - BounceOut(1f - t, 0f, max) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BounceInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return BounceIn(t * 2f, 0f, max) * 0.5f + min;
			} else {
				return BounceOut(t * 2f - 1f, 0f, max) * 0.5f + max * 0.5f + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BounceOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return BounceOut(t * 2f, min, max / 2f);
			} else {
				return BounceIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BackOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * ((t = t - 1f) * t * ((1.70158f + 1f) * t + 1.70158f) + 1f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BackIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			return max * t * t * ((1.70158f + 1f) * t - 1.70158f) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BackInOut(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			float s = 1.70158f;

			if ((t /= 0.5f) < 1f) {
				return max / 2f * (t * t * (((s *= (1.525f)) + 1f) * t - s)) + min;
			} else {
				return max / 2f * ((t -= 2f) * t * (((s *= (1.525f)) + 1f) * t + s) + 2f) + min;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float BackOutIn(float t, float min = 0f, float max = 1f)
		{
			if (t == 0f)
				return min;
			if (t == 1f)
				return max;
			max -= min;

			if (t < 0.5f) {
				return BackOut(t * 2f, min, max / 2f);
			} else {
				return BackIn((t * 2f) - 1f, min + max / 2f, max / 2f);
			}
		}
	}
}
