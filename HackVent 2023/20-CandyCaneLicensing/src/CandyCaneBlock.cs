using System;

namespace CandyCaneLicensing
{
	// Token: 0x02000007 RID: 7
	public struct CandyCaneBlock
	{
		// Token: 0x04000048 RID: 72
		public uint Expiration;

		// Token: 0x04000049 RID: 73
		public uint Generation;

		// Token: 0x0400004A RID: 74
		public byte Product;

		// Token: 0x0400004B RID: 75
		public byte Flags;

		// Token: 0x0400004C RID: 76
		public ushort Count;

		// Token: 0x0400004D RID: 77
		public ushort Random;

		// Token: 0x0400004E RID: 78
		public byte Type;

		// Token: 0x0400004F RID: 79
		public byte Shuffle;
	}
}
