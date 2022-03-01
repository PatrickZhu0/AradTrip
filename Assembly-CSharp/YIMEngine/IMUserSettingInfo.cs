using System;

namespace YIMEngine
{
	// Token: 0x02004A73 RID: 19059
	public class IMUserSettingInfo
	{
		// Token: 0x0601B97F RID: 113023 RVA: 0x0087B8C0 File Offset: 0x00879CC0
		public IMUserSettingInfo()
		{
			this.strNickName = string.Empty;
			this.iSex = IMUserSex.SEX_UNKNOWN;
			this.strSignature = string.Empty;
			this.strCountry = string.Empty;
			this.strProvince = string.Empty;
			this.strCity = string.Empty;
			this.strExtraInfo = string.Empty;
		}

		// Token: 0x170024DC RID: 9436
		// (get) Token: 0x0601B980 RID: 113024 RVA: 0x0087B91C File Offset: 0x00879D1C
		// (set) Token: 0x0601B981 RID: 113025 RVA: 0x0087B924 File Offset: 0x00879D24
		public string NickName
		{
			get
			{
				return this.strNickName;
			}
			set
			{
				this.strNickName = value;
			}
		}

		// Token: 0x170024DD RID: 9437
		// (get) Token: 0x0601B982 RID: 113026 RVA: 0x0087B92D File Offset: 0x00879D2D
		// (set) Token: 0x0601B983 RID: 113027 RVA: 0x0087B935 File Offset: 0x00879D35
		public IMUserSex Sex
		{
			get
			{
				return this.iSex;
			}
			set
			{
				this.iSex = value;
			}
		}

		// Token: 0x170024DE RID: 9438
		// (get) Token: 0x0601B984 RID: 113028 RVA: 0x0087B93E File Offset: 0x00879D3E
		// (set) Token: 0x0601B985 RID: 113029 RVA: 0x0087B946 File Offset: 0x00879D46
		public string Signature
		{
			get
			{
				return this.strSignature;
			}
			set
			{
				this.strSignature = value;
			}
		}

		// Token: 0x170024DF RID: 9439
		// (get) Token: 0x0601B986 RID: 113030 RVA: 0x0087B94F File Offset: 0x00879D4F
		// (set) Token: 0x0601B987 RID: 113031 RVA: 0x0087B957 File Offset: 0x00879D57
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

		// Token: 0x170024E0 RID: 9440
		// (get) Token: 0x0601B988 RID: 113032 RVA: 0x0087B960 File Offset: 0x00879D60
		// (set) Token: 0x0601B989 RID: 113033 RVA: 0x0087B968 File Offset: 0x00879D68
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

		// Token: 0x170024E1 RID: 9441
		// (get) Token: 0x0601B98A RID: 113034 RVA: 0x0087B971 File Offset: 0x00879D71
		// (set) Token: 0x0601B98B RID: 113035 RVA: 0x0087B979 File Offset: 0x00879D79
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

		// Token: 0x170024E2 RID: 9442
		// (get) Token: 0x0601B98C RID: 113036 RVA: 0x0087B982 File Offset: 0x00879D82
		// (set) Token: 0x0601B98D RID: 113037 RVA: 0x0087B98A File Offset: 0x00879D8A
		public string ExtraInfo
		{
			get
			{
				return this.strExtraInfo;
			}
			set
			{
				this.strExtraInfo = value;
			}
		}

		// Token: 0x040133FF RID: 78847
		private string strNickName;

		// Token: 0x04013400 RID: 78848
		private IMUserSex iSex;

		// Token: 0x04013401 RID: 78849
		private string strSignature;

		// Token: 0x04013402 RID: 78850
		private string strCountry;

		// Token: 0x04013403 RID: 78851
		private string strProvince;

		// Token: 0x04013404 RID: 78852
		private string strCity;

		// Token: 0x04013405 RID: 78853
		private string strExtraInfo;
	}
}
