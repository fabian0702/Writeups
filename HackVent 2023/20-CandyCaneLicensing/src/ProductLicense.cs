using System;
using System.Runtime.CompilerServices;

namespace CandyCaneLicensing
{
	// Token: 0x02000009 RID: 9
	public class ProductLicense
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000315D File Offset: 0x0000135D
		[NullableContext(1)]
		private static bool IsDefined<[Nullable(2)] T>(T value)
		{
			return Enum.IsDefined(typeof(T), value);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003174 File Offset: 0x00001374
		internal static bool IsProductDefined(int value)
		{
			return ProductLicense.IsDefined<ProductLicense.ProductNames>((ProductLicense.ProductNames)value);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000317C File Offset: 0x0000137C
		internal static bool IsProductTypeDefined(int value)
		{
			return ProductLicense.IsDefined<ProductLicense.ProductTypes>((ProductLicense.ProductTypes)value);
		}

		// Token: 0x0200000B RID: 11
		public enum ProductNames
		{
			// Token: 0x04000094 RID: 148
			CandyCaneMachine,
			// Token: 0x04000095 RID: 149
			CandyCaneMachine2000
		}

		// Token: 0x0200000C RID: 12
		public enum ProductTypes
		{
			// Token: 0x04000097 RID: 151
			Standard,
			// Token: 0x04000098 RID: 152
			Advanced,
			// Token: 0x04000099 RID: 153
			Premium
		}
	}
}
