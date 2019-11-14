using System;
using System.Runtime.CompilerServices;

namespace Flex.Math
{
	public sealed class Xorshift
	{
		public uint Seed { get; private set; }

		uint x;
		uint y;
		uint z;
		uint w;


		public Xorshift() : this((uint)DateTime.Now.Ticks) { }

		public Xorshift(uint seed)
		{
			x = 123456789U;
			y = 362436069U;
			z = 521288629U;
			w = seed;
			Seed = seed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		uint Next()
		{
			uint t = x ^ (x << 11);
			x = y;
			y = z;
			z = w;
			w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));

			return w;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Range(int min = 0, int max = 0x7FFFFFFF)
		{
			return (int)(Next() % (max - min + 1)) + min;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Range(float min = 0f, float max = 1f)
		{
			return (float)(Next() % 0xFFFF) / 0xFFFF * (max - min) + min;
		}
	}
}
