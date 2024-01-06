using System;
using System.Runtime.CompilerServices;

namespace CandyCaneLicensing
{
	// Token: 0x02000008 RID: 8
	public class CandyCaneLicense
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00003030 File Offset: 0x00001230
		[NullableContext(1)]
		[return: Nullable(2)]
		public static CandyCaneLicense Create(string serial)
		{
			CandyCaneLicense candyCaneLicense = new CandyCaneLicense();
			if (CandyCane.DecodeBlock(serial, out candyCaneLicense.candyCane) && candyCaneLicense.RangesAreValid())
			{
				return candyCaneLicense;
			}
			return null;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000305C File Offset: 0x0000125C
		public DateTime GetExpirationDate()
		{
			return CandyCaneLicense.UnixToDateTime(this.candyCane.Expiration);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000306E File Offset: 0x0000126E
		public DateTime GetRegistrationDate()
		{
			return CandyCaneLicense.UnixToDateTime(this.candyCane.Generation);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003080 File Offset: 0x00001280
		public bool IsExpired()
		{
			return this.GetExpirationDate() < DateTime.Now;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003094 File Offset: 0x00001294
		private bool RangesAreValid()
		{
			return this.candyCane.Expiration > 1621805003U && this.candyCane.Generation > 1621805003U && ProductLicense.IsProductDefined((int)this.candyCane.Product) && ProductLicense.IsProductTypeDefined((int)this.candyCane.Type);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000030EC File Offset: 0x000012EC
		private static DateTime UnixToDateTime(uint unix)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return dateTime.AddSeconds(unix).ToUniversalTime();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000014 RID: 20 RVA: 0x0000311E File Offset: 0x0000131E
		public int Count
		{
			get
			{
				return (int)this.candyCane.Count;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000312B File Offset: 0x0000132B
		public DateTime ExpirationDate
		{
			get
			{
				return this.GetExpirationDate();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00003133 File Offset: 0x00001333
		public ProductLicense.ProductNames ProductName
		{
			get
			{
				return (ProductLicense.ProductNames)this.candyCane.Product;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00003140 File Offset: 0x00001340
		public ProductLicense.ProductTypes ProductType
		{
			get
			{
				return (ProductLicense.ProductTypes)this.candyCane.Type;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000314D File Offset: 0x0000134D
		public DateTime RegistrationDate
		{
			get
			{
				return this.GetRegistrationDate();
			}
		}

		// Token: 0x04000050 RID: 80
		private CandyCaneBlock candyCane;
	}
}
