using System;

namespace YIMEngine
{
	// Token: 0x02004A64 RID: 19044
	public class RelativeLocation
	{
		// Token: 0x170024C1 RID: 9409
		// (get) Token: 0x0601B946 RID: 112966 RVA: 0x0087B6DB File Offset: 0x00879ADB
		// (set) Token: 0x0601B947 RID: 112967 RVA: 0x0087B6E3 File Offset: 0x00879AE3
		public uint Distance
		{
			get
			{
				return this.iDistance;
			}
			set
			{
				this.iDistance = value;
			}
		}

		// Token: 0x170024C2 RID: 9410
		// (get) Token: 0x0601B948 RID: 112968 RVA: 0x0087B6EC File Offset: 0x00879AEC
		// (set) Token: 0x0601B949 RID: 112969 RVA: 0x0087B6F4 File Offset: 0x00879AF4
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

		// Token: 0x170024C3 RID: 9411
		// (get) Token: 0x0601B94A RID: 112970 RVA: 0x0087B6FD File Offset: 0x00879AFD
		// (set) Token: 0x0601B94B RID: 112971 RVA: 0x0087B705 File Offset: 0x00879B05
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

		// Token: 0x170024C4 RID: 9412
		// (get) Token: 0x0601B94C RID: 112972 RVA: 0x0087B70E File Offset: 0x00879B0E
		// (set) Token: 0x0601B94D RID: 112973 RVA: 0x0087B716 File Offset: 0x00879B16
		public string UserID
		{
			get
			{
				return this.strUserID;
			}
			set
			{
				this.strUserID = value;
			}
		}

		// Token: 0x170024C5 RID: 9413
		// (get) Token: 0x0601B94E RID: 112974 RVA: 0x0087B71F File Offset: 0x00879B1F
		// (set) Token: 0x0601B94F RID: 112975 RVA: 0x0087B727 File Offset: 0x00879B27
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

		// Token: 0x170024C6 RID: 9414
		// (get) Token: 0x0601B950 RID: 112976 RVA: 0x0087B730 File Offset: 0x00879B30
		// (set) Token: 0x0601B951 RID: 112977 RVA: 0x0087B738 File Offset: 0x00879B38
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

		// Token: 0x170024C7 RID: 9415
		// (get) Token: 0x0601B952 RID: 112978 RVA: 0x0087B741 File Offset: 0x00879B41
		// (set) Token: 0x0601B953 RID: 112979 RVA: 0x0087B749 File Offset: 0x00879B49
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

		// Token: 0x170024C8 RID: 9416
		// (get) Token: 0x0601B954 RID: 112980 RVA: 0x0087B752 File Offset: 0x00879B52
		// (set) Token: 0x0601B955 RID: 112981 RVA: 0x0087B75A File Offset: 0x00879B5A
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

		// Token: 0x170024C9 RID: 9417
		// (get) Token: 0x0601B956 RID: 112982 RVA: 0x0087B763 File Offset: 0x00879B63
		// (set) Token: 0x0601B957 RID: 112983 RVA: 0x0087B76B File Offset: 0x00879B6B
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

		// Token: 0x040133B0 RID: 78768
		private uint iDistance;

		// Token: 0x040133B1 RID: 78769
		private double fLongitude;

		// Token: 0x040133B2 RID: 78770
		private double fLatitude;

		// Token: 0x040133B3 RID: 78771
		private string strUserID;

		// Token: 0x040133B4 RID: 78772
		private string strCountry;

		// Token: 0x040133B5 RID: 78773
		private string strProvince;

		// Token: 0x040133B6 RID: 78774
		private string strCity;

		// Token: 0x040133B7 RID: 78775
		private string strDistrictCounty;

		// Token: 0x040133B8 RID: 78776
		private string strStreet;
	}
}
