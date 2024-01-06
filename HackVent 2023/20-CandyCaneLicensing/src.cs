
// /home/giank/Downloads/CandyCaneLicensing.dll
// CandyCaneLicensing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Global type: <Module>
// Architecture: AnyCPU (64-bit preferred)
// Runtime: v4.0.30319
// Hash algorithm: SHA1

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v7.0", FrameworkDisplayName = ".NET 7.0")]
[assembly: AssemblyCompany("CandyCaneLicensing")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("CandyCaneLicensing")]
[assembly: AssemblyTitle("CandyCaneLicensing")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace CandyCaneLicensing
{

	public static class CandyCane
	{
		private static readonly byte[] candyMap = new byte[256]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			0, 1, 2, 3, 4, 5, 6, 7, 255, 255,
			255, 255, 255, 255, 255, 8, 9, 10, 11, 12,
			13, 14, 15, 255, 16, 17, 18, 19, 20, 255,
			21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
			31, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
			255, 255, 255, 255, 255, 255
		};

		private static readonly byte[] candyMixVertical00 = new byte[24]
		{
			23, 9, 22, 21, 11, 15, 13, 16, 17, 4,
			10, 3, 19, 7, 18, 1, 5, 6, 20, 12,
			2, 0, 14, 8
		};

		private static readonly byte[] candyMixVertical01 = new byte[24]
		{
			10, 13, 9, 18, 12, 7, 2, 22, 16, 0,
			23, 17, 4, 19, 15, 6, 8, 20, 1, 5,
			14, 21, 11, 3
		};

		private static readonly byte[] candyMixVertical02 = new byte[24]
		{
			21, 6, 19, 15, 5, 0, 17, 18, 3, 22,
			7, 16, 8, 14, 1, 23, 9, 10, 11, 12,
			13, 4, 2, 20
		};

		private static readonly byte[] candyMixVertical03 = new byte[24]
		{
			22, 8, 15, 7, 1, 14, 2, 16, 3, 12,
			21, 4, 19, 20, 10, 5, 18, 11, 17, 0,
			6, 9, 23, 13
		};

		private static readonly byte[] candyMixVertical04 = new byte[24]
		{
			18, 19, 1, 2, 6, 20, 5, 14, 23, 22,
			21, 17, 8, 4, 10, 11, 3, 9, 0, 7,
			16, 12, 13, 15
		};

		private static readonly byte[] candyMixVertical05 = new byte[24]
		{
			22, 15, 23, 12, 7, 1, 11, 2, 17, 10,
			3, 16, 14, 0, 21, 8, 13, 5, 6, 9,
			19, 4, 18, 20
		};

		private static readonly byte[] candyMixVertical06 = new byte[24]
		{
			11, 18, 21, 8, 20, 23, 17, 3, 2, 22,
			7, 10, 0, 4, 1, 19, 13, 9, 12, 5,
			16, 6, 15, 14
		};

		private static readonly byte[] candyMixVertical07 = new byte[24]
		{
			7, 2, 6, 15, 12, 11, 10, 21, 8, 18,
			19, 23, 17, 20, 0, 9, 4, 13, 1, 22,
			5, 14, 16, 3
		};

		private static readonly byte[] candyMixVertical08 = new byte[24]
		{
			16, 4, 20, 15, 1, 8, 0, 2, 17, 5,
			3, 12, 10, 18, 7, 21, 23, 6, 9, 13,
			22, 19, 14, 11
		};

		private static readonly byte[] candyMixVertical09 = new byte[24]
		{
			12, 4, 22, 2, 10, 14, 6, 20, 3, 16,
			1, 9, 18, 0, 15, 5, 11, 13, 19, 17,
			23, 7, 8, 21
		};

		private static readonly byte[] candyMixVertical0A = new byte[24]
		{
			0, 16, 6, 13, 7, 15, 17, 23, 21, 22,
			4, 19, 1, 9, 11, 20, 8, 3, 12, 2,
			14, 5, 10, 18
		};

		private static readonly byte[] candyMixVertical0B = new byte[24]
		{
			10, 21, 6, 16, 8, 4, 5, 0, 3, 9,
			7, 2, 13, 12, 11, 20, 1, 18, 17, 19,
			22, 14, 23, 15
		};

		private static readonly byte[] candyMixVertical0C = new byte[24]
		{
			19, 6, 17, 13, 8, 1, 4, 21, 2, 11,
			7, 9, 5, 16, 14, 10, 0, 12, 20, 23,
			3, 22, 15, 18
		};

		private static readonly byte[] candyMixVertical0D = new byte[24]
		{
			22, 1, 8, 4, 11, 2, 18, 13, 10, 7,
			14, 0, 19, 23, 20, 9, 16, 15, 17, 3,
			21, 6, 5, 12
		};

		private static readonly byte[] candyMixVertical0E = new byte[24]
		{
			20, 18, 3, 19, 4, 6, 0, 15, 13, 17,
			16, 22, 9, 23, 14, 2, 12, 1, 10, 8,
			7, 11, 21, 5
		};

		private static readonly byte[] candyMixVertical0F = new byte[24]
		{
			15, 13, 9, 12, 1, 16, 3, 0, 23, 21,
			17, 6, 19, 8, 22, 11, 14, 5, 20, 2,
			18, 10, 4, 7
		};

		private static readonly byte[] candyMixVertical10 = new byte[24]
		{
			13, 18, 4, 14, 9, 19, 2, 5, 16, 17,
			10, 3, 7, 15, 21, 20, 8, 22, 11, 23,
			1, 6, 0, 12
		};

		private static readonly byte[] candyMixVertical11 = new byte[24]
		{
			21, 14, 10, 11, 13, 0, 3, 23, 17, 7,
			15, 5, 12, 19, 22, 6, 9, 1, 2, 8,
			18, 16, 20, 4
		};

		private static readonly byte[] candyMixVertical12 = new byte[24]
		{
			17, 22, 0, 20, 8, 12, 15, 13, 10, 2,
			9, 14, 11, 4, 5, 18, 19, 16, 23, 1,
			21, 6, 7, 3
		};

		private static readonly byte[] candyMixVertical13 = new byte[24]
		{
			5, 15, 17, 2, 13, 1, 11, 23, 10, 22,
			4, 20, 8, 6, 16, 18, 9, 0, 14, 12,
			7, 3, 21, 19
		};

		private static readonly byte[] candyMixVertical14 = new byte[24]
		{
			1, 6, 22, 14, 3, 21, 4, 17, 2, 0,
			9, 13, 10, 11, 23, 16, 15, 7, 19, 18,
			8, 12, 5, 20
		};

		private static readonly byte[] candyMixVertical15 = new byte[24]
		{
			21, 7, 6, 17, 9, 11, 14, 16, 2, 10,
			5, 8, 22, 19, 15, 23, 4, 20, 18, 12,
			1, 13, 0, 3
		};

		private static readonly byte[] candyMixVertical16 = new byte[24]
		{
			11, 18, 9, 12, 17, 13, 10, 22, 0, 1,
			20, 16, 7, 19, 15, 3, 5, 8, 14, 21,
			2, 23, 6, 4
		};

		private static readonly byte[] candyMixVertical17 = new byte[24]
		{
			15, 12, 5, 22, 23, 4, 8, 18, 16, 11,
			0, 14, 7, 6, 20, 17, 2, 19, 21, 10,
			1, 9, 13, 3
		};

		private static readonly byte[] candyMixVertical18 = new byte[24]
		{
			16, 22, 2, 14, 11, 8, 7, 1, 17, 4,
			13, 23, 12, 5, 21, 10, 9, 15, 0, 6,
			3, 19, 20, 18
		};

		private static readonly byte[] candyMixVertical19 = new byte[24]
		{
			20, 14, 5, 10, 12, 1, 8, 7, 13, 2,
			6, 16, 22, 23, 4, 11, 9, 3, 15, 17,
			19, 18, 0, 21
		};

		private static readonly byte[] candyMixVertical1A = new byte[24]
		{
			5, 14, 0, 23, 18, 16, 11, 1, 20, 2,
			8, 10, 15, 6, 22, 19, 9, 4, 21, 17,
			3, 7, 13, 12
		};

		private static readonly byte[] candyMixVertical1B = new byte[24]
		{
			13, 7, 17, 18, 14, 0, 22, 21, 10, 12,
			3, 5, 8, 23, 6, 20, 15, 4, 9, 19,
			1, 16, 2, 11
		};

		private static readonly byte[] candyMixVertical1C = new byte[24]
		{
			6, 11, 4, 2, 20, 7, 22, 13, 3, 18,
			14, 15, 5, 10, 17, 16, 21, 1, 0, 12,
			19, 8, 9, 23
		};

		private static readonly byte[] candyMixVertical1D = new byte[24]
		{
			7, 4, 10, 2, 8, 23, 19, 12, 6, 5,
			9, 13, 0, 22, 11, 16, 21, 1, 14, 3,
			17, 20, 15, 18
		};

		private static readonly byte[] candyMixVertical1E = new byte[24]
		{
			14, 22, 21, 16, 10, 4, 17, 15, 13, 12,
			9, 0, 20, 11, 5, 7, 2, 19, 3, 18,
			23, 8, 1, 6
		};

		private static readonly byte[] candyMixVertical1F = new byte[24]
		{
			18, 21, 4, 13, 17, 15, 1, 11, 10, 6,
			20, 9, 7, 5, 19, 0, 2, 3, 12, 23,
			14, 8, 22, 16
		};

		private static readonly byte[][] candyMixVerticals = new byte[32][]
		{
			candyMixVertical00, candyMixVertical01, candyMixVertical02, candyMixVertical03, candyMixVertical04, candyMixVertical05, candyMixVertical06, candyMixVertical07, candyMixVertical08, candyMixVertical09,
			candyMixVertical0A, candyMixVertical0B, candyMixVertical0C, candyMixVertical0D, candyMixVertical0E, candyMixVertical0F, candyMixVertical10, candyMixVertical11, candyMixVertical12, candyMixVertical13,
			candyMixVertical14, candyMixVertical15, candyMixVertical16, candyMixVertical17, candyMixVertical18, candyMixVertical19, candyMixVertical1A, candyMixVertical1B, candyMixVertical1C, candyMixVertical1D,
			candyMixVertical1E, candyMixVertical1F
		};

		private static readonly byte[] shuffler = new byte[24]
		{
			26, 1, 5, 20, 15, 2, 21, 25, 27, 3,
			13, 31, 20, 27, 27, 11, 18, 27, 26, 11,
			0, 23, 3, 26
		};

		private static readonly byte[] candyMixHorizontal00 = new byte[32]
		{
			26, 27, 6, 4, 31, 15, 20, 2, 28, 12,
			0, 23, 24, 18, 5, 8, 10, 25, 3, 21,
			7, 9, 22, 13, 14, 1, 16, 30, 17, 19,
			29, 11
		};

		private static readonly byte[] candyMixHorizontal01 = new byte[32]
		{
			9, 6, 30, 22, 20, 28, 5, 31, 0, 24,
			21, 2, 4, 27, 16, 12, 29, 18, 25, 17,
			11, 26, 1, 19, 10, 8, 3, 14, 15, 13,
			7, 23
		};

		private static readonly byte[] candyMixHorizontal02 = new byte[32]
		{
			6, 8, 19, 7, 16, 23, 20, 12, 28, 21,
			1, 5, 14, 3, 13, 29, 9, 11, 10, 31,
			27, 26, 4, 30, 18, 17, 15, 24, 22, 25,
			0, 2
		};

		private static readonly byte[] candyMixHorizontal03 = new byte[32]
		{
			10, 23, 5, 15, 21, 18, 25, 11, 31, 19,
			16, 20, 12, 22, 8, 26, 17, 24, 4, 30,
			0, 14, 6, 13, 2, 9, 28, 27, 1, 29,
			7, 3
		};

		private static readonly byte[] candyMixHorizontal04 = new byte[32]
		{
			26, 14, 11, 18, 24, 8, 17, 6, 31, 23,
			28, 9, 3, 1, 7, 16, 15, 19, 13, 2,
			29, 10, 22, 27, 30, 0, 12, 25, 5, 4,
			21, 20
		};

		private static readonly byte[] candyMixHorizontal05 = new byte[32]
		{
			30, 16, 3, 0, 6, 24, 18, 14, 22, 26,
			29, 27, 8, 10, 1, 31, 25, 13, 12, 7,
			15, 23, 5, 20, 17, 19, 11, 21, 2, 4,
			28, 9
		};

		private static readonly byte[] candyMixHorizontal06 = new byte[32]
		{
			1, 31, 17, 27, 16, 4, 5, 10, 15, 20,
			14, 2, 22, 21, 23, 25, 0, 12, 13, 28,
			6, 3, 11, 29, 9, 18, 24, 30, 26, 7,
			8, 19
		};

		private static readonly byte[] candyMixHorizontal07 = new byte[32]
		{
			15, 31, 18, 25, 1, 21, 3, 29, 6, 2,
			27, 11, 24, 28, 0, 30, 4, 19, 20, 23,
			7, 12, 22, 14, 16, 9, 26, 10, 5, 17,
			13, 8
		};

		private static readonly byte[] candyMixHorizontal08 = new byte[32]
		{
			19, 2, 17, 9, 31, 11, 4, 30, 29, 13,
			0, 25, 15, 23, 26, 1, 21, 20, 6, 22,
			27, 16, 7, 24, 10, 18, 28, 14, 8, 5,
			3, 12
		};

		private static readonly byte[] candyMixHorizontal09 = new byte[32]
		{
			28, 24, 4, 13, 18, 12, 23, 7, 5, 30,
			19, 3, 2, 17, 27, 15, 16, 25, 21, 14,
			31, 10, 8, 22, 11, 1, 20, 29, 0, 9,
			6, 26
		};

		private static readonly byte[] candyMixHorizontal0A = new byte[32]
		{
			8, 13, 14, 31, 21, 11, 16, 25, 28, 5,
			2, 1, 22, 24, 17, 15, 10, 23, 7, 9,
			19, 29, 20, 18, 4, 30, 27, 6, 0, 3,
			26, 12
		};

		private static readonly byte[] candyMixHorizontal0B = new byte[32]
		{
			24, 27, 29, 31, 21, 30, 18, 12, 13, 0,
			9, 26, 2, 6, 19, 23, 16, 11, 28, 5,
			1, 14, 7, 15, 10, 4, 25, 20, 3, 22,
			17, 8
		};

		private static readonly byte[] candyMixHorizontal0C = new byte[32]
		{
			15, 9, 19, 27, 6, 30, 22, 17, 24, 14,
			31, 10, 25, 16, 18, 12, 29, 20, 4, 7,
			3, 8, 1, 26, 11, 0, 23, 28, 5, 21,
			13, 2
		};

		private static readonly byte[] candyMixHorizontal0D = new byte[32]
		{
			5, 13, 1, 23, 31, 18, 27, 12, 20, 15,
			14, 8, 7, 29, 24, 11, 30, 3, 26, 17,
			19, 25, 21, 22, 0, 10, 4, 28, 2, 16,
			6, 9
		};

		private static readonly byte[] candyMixHorizontal0E = new byte[32]
		{
			29, 27, 15, 12, 30, 0, 4, 9, 14, 7,
			22, 19, 5, 31, 8, 18, 6, 11, 23, 24,
			2, 17, 3, 26, 21, 16, 1, 10, 20, 25,
			13, 28
		};

		private static readonly byte[] candyMixHorizontal0F = new byte[32]
		{
			27, 1, 10, 15, 3, 21, 11, 9, 2, 25,
			12, 30, 31, 29, 22, 28, 6, 17, 20, 7,
			8, 5, 19, 13, 0, 16, 14, 4, 18, 23,
			24, 26
		};

		private static readonly byte[] candyMixHorizontal10 = new byte[32]
		{
			27, 26, 5, 20, 17, 25, 15, 10, 9, 28,
			21, 7, 2, 8, 0, 23, 6, 24, 31, 3,
			4, 11, 22, 13, 1, 12, 16, 30, 19, 14,
			18, 29
		};

		private static readonly byte[] candyMixHorizontal11 = new byte[32]
		{
			6, 14, 27, 13, 29, 22, 11, 19, 18, 4,
			21, 16, 30, 17, 8, 26, 0, 25, 12, 7,
			28, 3, 10, 20, 9, 24, 2, 23, 5, 15,
			1, 31
		};

		private static readonly byte[] candyMixHorizontal12 = new byte[32]
		{
			1, 29, 9, 0, 20, 5, 18, 4, 27, 6,
			24, 30, 15, 2, 25, 13, 7, 14, 19, 8,
			17, 3, 11, 21, 12, 31, 23, 10, 22, 28,
			26, 16
		};

		private static readonly byte[] candyMixHorizontal13 = new byte[32]
		{
			16, 30, 24, 5, 28, 1, 27, 29, 11, 21,
			14, 26, 8, 4, 13, 3, 2, 6, 9, 25,
			23, 7, 10, 20, 0, 17, 22, 18, 12, 15,
			19, 31
		};

		private static readonly byte[] candyMixHorizontal14 = new byte[32]
		{
			0, 28, 15, 30, 31, 3, 24, 16, 23, 17,
			1, 11, 4, 2, 7, 13, 19, 12, 25, 27,
			20, 10, 18, 8, 14, 6, 21, 29, 26, 22,
			5, 9
		};

		private static readonly byte[] candyMixHorizontal15 = new byte[32]
		{
			24, 0, 19, 15, 22, 11, 14, 28, 12, 8,
			25, 17, 26, 23, 3, 31, 18, 13, 5, 7,
			30, 4, 27, 1, 16, 2, 21, 10, 9, 20,
			29, 6
		};

		private static readonly byte[] candyMixHorizontal16 = new byte[32]
		{
			14, 25, 1, 15, 28, 26, 27, 10, 13, 22,
			19, 9, 3, 18, 23, 2, 21, 0, 6, 16,
			4, 12, 8, 24, 29, 17, 11, 30, 20, 31,
			5, 7
		};

		private static readonly byte[] candyMixHorizontal17 = new byte[32]
		{
			16, 12, 31, 17, 13, 28, 9, 4, 1, 10,
			27, 30, 5, 26, 21, 6, 15, 7, 24, 11,
			8, 14, 29, 22, 19, 20, 0, 3, 2, 25,
			18, 23
		};

		private static readonly byte[] candyMixHorizontal18 = new byte[32]
		{
			18, 19, 30, 15, 29, 11, 16, 26, 1, 25,
			8, 9, 31, 3, 13, 20, 6, 23, 4, 28,
			12, 10, 21, 5, 17, 14, 24, 22, 2, 27,
			0, 7
		};

		private static readonly byte[] candyMixHorizontal19 = new byte[32]
		{
			26, 15, 13, 22, 21, 0, 16, 17, 28, 8,
			29, 20, 4, 14, 27, 3, 19, 24, 23, 30,
			9, 5, 25, 10, 6, 31, 18, 11, 2, 7,
			1, 12
		};

		private static readonly byte[] candyMixHorizontal1A = new byte[32]
		{
			10, 4, 11, 25, 1, 12, 14, 21, 16, 26,
			31, 27, 20, 5, 24, 17, 19, 0, 28, 15,
			7, 8, 29, 23, 3, 2, 22, 30, 9, 18,
			13, 6
		};

		private static readonly byte[] candyMixHorizontal1B = new byte[32]
		{
			13, 12, 29, 0, 1, 28, 30, 20, 5, 27,
			8, 7, 19, 18, 16, 17, 10, 2, 15, 22,
			21, 31, 4, 6, 23, 9, 11, 14, 24, 3,
			26, 25
		};

		private static readonly byte[] candyMixHorizontal1C = new byte[32]
		{
			21, 23, 19, 28, 1, 10, 6, 17, 9, 16,
			13, 8, 3, 29, 26, 2, 7, 0, 27, 22,
			15, 5, 14, 12, 20, 25, 18, 24, 4, 31,
			30, 11
		};

		private static readonly byte[] candyMixHorizontal1D = new byte[32]
		{
			26, 15, 18, 21, 0, 22, 6, 11, 24, 29,
			14, 2, 31, 23, 1, 30, 25, 3, 5, 12,
			13, 17, 19, 28, 4, 7, 16, 9, 8, 27,
			10, 20
		};

		private static readonly byte[] candyMixHorizontal1E = new byte[32]
		{
			14, 25, 27, 8, 24, 17, 2, 11, 1, 12,
			19, 16, 0, 30, 29, 6, 22, 3, 21, 15,
			13, 18, 20, 28, 7, 31, 26, 5, 9, 4,
			23, 10
		};

		private static readonly byte[] candyMixHorizontal1F = new byte[32]
		{
			12, 10, 11, 20, 19, 8, 18, 6, 0, 28,
			29, 26, 15, 23, 27, 31, 1, 5, 30, 13,
			25, 16, 7, 2, 4, 17, 14, 22, 24, 9,
			21, 3
		};

		private static readonly byte[][] candyMixHorizontals = new byte[32][]
		{
			candyMixHorizontal00, candyMixHorizontal01, candyMixHorizontal02, candyMixHorizontal03, candyMixHorizontal04, candyMixHorizontal05, candyMixHorizontal06, candyMixHorizontal07, candyMixHorizontal08, candyMixHorizontal09,
			candyMixHorizontal0A, candyMixHorizontal0B, candyMixHorizontal0C, candyMixHorizontal0D, candyMixHorizontal0E, candyMixHorizontal0F, candyMixHorizontal10, candyMixHorizontal11, candyMixHorizontal12, candyMixHorizontal13,
			candyMixHorizontal14, candyMixHorizontal15, candyMixHorizontal16, candyMixHorizontal17, candyMixHorizontal18, candyMixHorizontal19, candyMixHorizontal1A, candyMixHorizontal1B, candyMixHorizontal1C, candyMixHorizontal1D,
			candyMixHorizontal1E, candyMixHorizontal1F
		};

		private static bool ArrayToBinary(IReadOnlyList<byte> arr, out byte[] bin)
		{
			bin = new byte[16];
			int num = 0;
			int index = 0;
			ulong num2 = ((ulong)arr[index++] << 35) | ((ulong)arr[index++] << 30) | ((ulong)arr[index++] << 25) | ((ulong)arr[index++] << 20) | ((ulong)arr[index++] << 15) | ((ulong)arr[index++] << 10) | ((ulong)arr[index++] << 5) | arr[index++];
			bin[num++] = (byte)((num2 >> 32) & 0xFF);
			bin[num++] = (byte)((num2 >> 24) & 0xFF);
			bin[num++] = (byte)((num2 >> 16) & 0xFF);
			bin[num++] = (byte)((num2 >> 8) & 0xFF);
			bin[num++] = (byte)(num2 & 0xFF);
			num2 = ((ulong)arr[index++] << 35) | ((ulong)arr[index++] << 30) | ((ulong)arr[index++] << 25) | ((ulong)arr[index++] << 20) | ((ulong)arr[index++] << 15) | ((ulong)arr[index++] << 10) | ((ulong)arr[index++] << 5) | arr[index++];
			bin[num++] = (byte)((num2 >> 32) & 0xFF);
			bin[num++] = (byte)((num2 >> 24) & 0xFF);
			bin[num++] = (byte)((num2 >> 16) & 0xFF);
			bin[num++] = (byte)((num2 >> 8) & 0xFF);
			bin[num++] = (byte)(num2 & 0xFF);
			num2 = ((ulong)arr[index++] << 35) | ((ulong)arr[index++] << 30) | ((ulong)arr[index++] << 25) | ((ulong)arr[index++] << 20) | ((ulong)arr[index++] << 15) | ((ulong)arr[index++] << 10) | ((ulong)arr[index++] << 5) | arr[index++];
			bin[num++] = (byte)((num2 >> 32) & 0xFF);
			bin[num++] = (byte)((num2 >> 24) & 0xFF);
			bin[num++] = (byte)((num2 >> 16) & 0xFF);
			bin[num++] = (byte)((num2 >> 8) & 0xFF);
			bin[num++] = (byte)(num2 & 0xFF);
			bin[num] = (byte)(arr[index] << 3);
			return true;
		}

		private static bool BinaryToArray(IReadOnlyList<byte> bin, out byte[] arr)
		{
			arr = new byte[25];
			int num = 0;
			int index = 0;
			ulong num2 = ((ulong)bin[index++] << 32) | ((ulong)bin[index++] << 24) | ((ulong)bin[index++] << 16) | ((ulong)bin[index++] << 8) | bin[index++];
			arr[num++] = (byte)((num2 >> 35) & 0x1F);
			arr[num++] = (byte)((num2 >> 30) & 0x1F);
			arr[num++] = (byte)((num2 >> 25) & 0x1F);
			arr[num++] = (byte)((num2 >> 20) & 0x1F);
			arr[num++] = (byte)((num2 >> 15) & 0x1F);
			arr[num++] = (byte)((num2 >> 10) & 0x1F);
			arr[num++] = (byte)((num2 >> 5) & 0x1F);
			arr[num++] = (byte)(num2 & 0x1F);
			num2 = ((ulong)bin[index++] << 32) | ((ulong)bin[index++] << 24) | ((ulong)bin[index++] << 16) | ((ulong)bin[index++] << 8) | bin[index++];
			arr[num++] = (byte)((num2 >> 35) & 0x1F);
			arr[num++] = (byte)((num2 >> 30) & 0x1F);
			arr[num++] = (byte)((num2 >> 25) & 0x1F);
			arr[num++] = (byte)((num2 >> 20) & 0x1F);
			arr[num++] = (byte)((num2 >> 15) & 0x1F);
			arr[num++] = (byte)((num2 >> 10) & 0x1F);
			arr[num++] = (byte)((num2 >> 5) & 0x1F);
			arr[num++] = (byte)(num2 & 0x1F);
			num2 = ((ulong)bin[index++] << 32) | ((ulong)bin[index++] << 24) | ((ulong)bin[index++] << 16) | ((ulong)bin[index++] << 8) | bin[index++];
			arr[num++] = (byte)((num2 >> 35) & 0x1F);
			arr[num++] = (byte)((num2 >> 30) & 0x1F);
			arr[num++] = (byte)((num2 >> 25) & 0x1F);
			arr[num++] = (byte)((num2 >> 20) & 0x1F);
			arr[num++] = (byte)((num2 >> 15) & 0x1F);
			arr[num++] = (byte)((num2 >> 10) & 0x1F);
			arr[num++] = (byte)((num2 >> 5) & 0x1F);
			arr[num++] = (byte)(num2 & 0x1F);
			arr[num] = (byte)(bin[index] >> 3);
			return true;
		}

		private static byte ComputeShuffle(IReadOnlyList<byte> arr)
		{
			uint num = 0u;
			for (int i = 0; i < 24; i++)
			{
				num += (uint)(arr[i] + shuffler[i]);
			}
			num %= 32u;
			return (byte)num;
		}

		public static bool DecodeBlock(string str, out CandyCaneBlock block)
		{
			block = default(CandyCaneBlock);
			if (!StringToArray(str, out var arr) || !UnshuffleArray(arr) || !ArrayToBinary(arr, out var bin))
			{
				return false;
			}
			IntPtr intPtr = Marshal.AllocHGlobal(25);
			Marshal.Copy(bin, 0, intPtr, 16);
			block = (CandyCaneBlock)Marshal.PtrToStructure(intPtr, typeof(CandyCaneBlock));
			Marshal.FreeHGlobal(intPtr);
			block.Shuffle = arr[24];

			// Console.WriteLine(block.Expiration);
			// Console.WriteLine(block.Generation);
			// Console.WriteLine(block.Type);
			// Console.WriteLine(block.Product);
			// Console.WriteLine(IsValidTime(block.Generation));
			// Console.WriteLine(block.Expiration > 1621805003);
			// Console.WriteLine(block.Generation > 1621805003);
			// Console.WriteLine( ProductLicense.IsProductDefined(block.Product));
			// Console.WriteLine(ProductLicense.IsProductTypeDefined(block.Type));
			// Console.WriteLine(block.Type);
			// Console.WriteLine(String.Join(",", bin));
			// Console.WriteLine(bin[13]);

			if (IsValidTime(block.Expiration))
			{
				return IsValidTime(block.Generation);
			}
			return false;
		}

		private static bool IsValidTime(uint time)
		{
			return time >= 1621805003;
		}

		private static bool StringToArray(string str, out byte[] arr)
		{
			arr = null;
			if (str == null || str.Length != 29 || str[5] != '-' || str[11] != '-' || str[17] != '-' || str[23] != '-')
			{
				return false;
			}
			int num = 0;
			arr = new byte[25];
			for (int i = 0; i < 29; i++)
			{
				switch (i)
				{
				case 5:
				case 11:
				case 17:
				case 23:
					continue;
				}
				byte b = candyMap[str[i] & 0xFF];
				if (b >= 32)
				{
					return false;
				}
				arr[num++] = b;
			}
			return true;
		}

		private static bool UnshuffleArray(byte[] arr)
		{
			byte b = ComputeShuffle(arr);
			byte b2 = arr[24];
			if (b >= 32 || b2 >= 32)
			{
				return false;
			}
			byte[] array = new byte[25];
			byte[] array2 = candyMixHorizontals[b2];
			for (int i = 0; i < 24; i++)
			{
				array[i] = array2[arr[i]];
			}
			byte[] array3 = candyMixVerticals[b];
			for (int j = 0; j < 24; j++)
			{
				arr[array3[j]] = array[j];
			}
			return true;
		}
	}
	public struct CandyCaneBlock
	{
		public uint Expiration;

		public uint Generation;

		public byte Product;

		public byte Flags;

		public ushort Count;

		public ushort Random;

		public byte Type;

		public byte Shuffle;
	}
    public class CandyCaneLicensing {
        public static void Main() {
            // read product key from stdin
            String productKey = Console.ReadLine();
            // decode product key
            CandyCaneLicense candyCane = CandyCaneLicense.Create(productKey);
            // check if product key is valid
            Console.WriteLine("Product key is " + (candyCane == null ? "invalid" : "valid"));
        }
    }
	public class CandyCaneLicense
	{


		private CandyCaneBlock candyCane;

		public int Count => candyCane.Count;

		public DateTime ExpirationDate => GetExpirationDate();

		public ProductLicense.ProductNames ProductName => (ProductLicense.ProductNames)candyCane.Product;

		public ProductLicense.ProductTypes ProductType => (ProductLicense.ProductTypes)candyCane.Type;

		public DateTime RegistrationDate => GetRegistrationDate();

		public static CandyCaneLicense Create(string serial)
		{
			CandyCaneLicense candyCaneLicense = new CandyCaneLicense();
			if (CandyCane.DecodeBlock(serial, out candyCaneLicense.candyCane) && candyCaneLicense.RangesAreValid())
			{
				return candyCaneLicense;
			}
			return null;
		}

		public DateTime GetExpirationDate()
		{
			return UnixToDateTime(candyCane.Expiration);
		}

		public DateTime GetRegistrationDate()
		{
			return UnixToDateTime(candyCane.Generation);
		}

		public bool IsExpired()
		{
			return GetExpirationDate() < DateTime.Now;
		}

		private bool RangesAreValid()
		{
			if (candyCane.Expiration > 1621805003 && candyCane.Generation > 1621805003 && ProductLicense.IsProductDefined(candyCane.Product))
			{
				return ProductLicense.IsProductTypeDefined(candyCane.Type);
			}
			return false;
		}

		private static DateTime UnixToDateTime(uint unix)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unix).ToUniversalTime();
		}
	}
	public class ProductLicense
	{
		public enum ProductNames
		{
			CandyCaneMachine,
			CandyCaneMachine2000
		}

		public enum ProductTypes
		{
			Standard,
			Advanced,
			Premium
		}

		private static bool IsDefined<T>(T value)
		{
			return Enum.IsDefined(typeof(T), value);
		}

		internal static bool IsProductDefined(int value)
		{
			return IsDefined((ProductNames)value);
		}

		internal static bool IsProductTypeDefined(int value)
		{
			return IsDefined((ProductTypes)value);
		}
	}
}
