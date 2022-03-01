using System;

namespace YIMEngine
{
	// Token: 0x02004A62 RID: 19042
	public class GeographyLocation
	{
		// Token: 0x170024B5 RID: 9397
		// (get) Token: 0x0601B92C RID: 112940 RVA: 0x0087B5FF File Offset: 0x008799FF
		// (set) Token: 0x0601B92D RID: 112941 RVA: 0x0087B607 File Offset: 0x00879A07
		public uint DistrictCode
		{
			get
			{
				return this.iDistrictCode;
			}
			set
			{
				this.iDistrictCode = value;
			}
		}

		// Token: 0x170024B6 RID: 9398
		// (get) Token: 0x0601B92E RID: 112942 RVA: 0x0087B610 File Offset: 0x00879A10
		// (set) Token: 0x0601B92F RID: 112943 RVA: 0x0087B618 File Offset: 0x00879A18
		public string Country
		{
			get
			{
				return this.strCountry;
			}
			set
			{
				this.strCountry = value;
			}
		}

		// Token: 0x170024B7 RID: 9399
		// (get) Token: 0x0601B930 RID: 112944 RVA: 0x0087B621 File Offset: 0x00879A21
		// (set) Token: 0x0601B931 RID: 112945 RVA: 0x0087B629 File Offset: 0x00879A29
		public string Province
		{
			get
			{
				return this.strProvince;
			}
			set
			{
				this.strProvince = value;
			}
		}

		// Token: 0x170024B8 RID: 9400
		// (get) Token: 0x0601B932 RID: 112946 RVA: 0x0087B632 File Offset: 0x00879A32
		// (set) Token: 0x0601B933 RID: 112947 RVA: 0x0087B63A File Offset: 0x00879A3A
		public string City
		{
			get
			{
				return this.strCity;
			}
			set
			{
				this.strCity = value;
			}
		}

		// Token: 0x170024B9 RID: 9401
		// (get) Token: 0x0601B934 RID: 112948 RVA: 0x0087B643 File Offset: 0x00879A43
		// (set) Token: 0x0601B935 RID: 112949 RVA: 0x0087B64B File Offset: 0x00879A4B
		public string DistrictCounty
		{
			get
			{
				return this.strDistrictCounty;
			}
			set
			{
				this.strDistrictCounty = value;
			}
		}

		// Token: 0x170024BA RID: 9402
		// (get) Token: 0x0601B936 RID: 112950 RVA: 0x0087B654 File Offset: 0x00879A54
		// (set) Token: 0x0601B937 RID: 112951 RVA: 0x0087B65C File Offset: 0x00879A5C
		public string Street
		{
			get
			{
				return this.strStreet;
			}
			set
			{
				this.strStreet = value;
			}
		}

		// Token: 0x170024BB RID: 9403
		// (get) Token: 0x0601B938 RID: 112952 RVA: 0x0087B665 File Offset: 0x00879A65
		// (set) Token: 0x0601B939 RID: 112953 RVA: 0x0087B66D File Offset: 0x00879A6D
		public double Longitude
		{
			get
			{
				return this.fLongitude;
			}
			set
			{
				this.fLongitude = value;
			}
		}

		// Token: 0x170024BC RID: 9404
		// (get) Token: 0x0601B93A RID: 112954 RVA: 0x0087B676 File Offset: 0x00879A76
		// (set) Token: 0x0601B93B RID: 112955 RVA: 0x0087B67E File Offset: 0x00879A7E
		public double Latitude
		{
			get
			{
				return this.fLatitude;
			}
			set
			{
				this.fLatitude = value;
			}
		}

		// Token: 0x040133A4 RID: 78756
		private uint iDistrictCode;

		// Token: 0x040133A5 RID: 78757
		private string strCountry;

		// Token: 0x040133A6 RID: 78758
		private string strProvince;

		// Token: 0x040133A7 RID: 78759
		private string strCity;

		// Token: 0x040133A8 RID: 78760
		private string strDistrictCounty;

		// Token: 0x040133A9 RID: 78761
		private string strStreet;

		// Token: 0x040133AA RID: 78762
		private double fLongitude;

		// Token: 0x040133AB RID: 78763
		private double fLatitude;
	}
}
