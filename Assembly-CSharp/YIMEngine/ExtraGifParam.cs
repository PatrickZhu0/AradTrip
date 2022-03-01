using System;

namespace YIMEngine
{
	// Token: 0x02004A49 RID: 19017
	public class ExtraGifParam
	{
		// Token: 0x17002468 RID: 9320
		// (get) Token: 0x0601B7CF RID: 112591 RVA: 0x008784DB File Offset: 0x008768DB
		// (set) Token: 0x0601B7D0 RID: 112592 RVA: 0x008784E3 File Offset: 0x008768E3
		public string NickName { get; set; }

		// Token: 0x17002469 RID: 9321
		// (get) Token: 0x0601B7D1 RID: 112593 RVA: 0x008784EC File Offset: 0x008768EC
		// (set) Token: 0x0601B7D2 RID: 112594 RVA: 0x008784F4 File Offset: 0x008768F4
		public string ServerArea { get; set; }

		// Token: 0x1700246A RID: 9322
		// (get) Token: 0x0601B7D3 RID: 112595 RVA: 0x008784FD File Offset: 0x008768FD
		// (set) Token: 0x0601B7D4 RID: 112596 RVA: 0x00878505 File Offset: 0x00876905
		public string Location { get; set; }

		// Token: 0x1700246B RID: 9323
		// (get) Token: 0x0601B7D5 RID: 112597 RVA: 0x0087850E File Offset: 0x0087690E
		// (set) Token: 0x0601B7D6 RID: 112598 RVA: 0x00878516 File Offset: 0x00876916
		public long Score { get; set; }

		// Token: 0x1700246C RID: 9324
		// (get) Token: 0x0601B7D7 RID: 112599 RVA: 0x0087851F File Offset: 0x0087691F
		// (set) Token: 0x0601B7D8 RID: 112600 RVA: 0x00878527 File Offset: 0x00876927
		public int Level { get; set; }

		// Token: 0x1700246D RID: 9325
		// (get) Token: 0x0601B7D9 RID: 112601 RVA: 0x00878530 File Offset: 0x00876930
		// (set) Token: 0x0601B7DA RID: 112602 RVA: 0x00878538 File Offset: 0x00876938
		public int VipLevel { get; set; }

		// Token: 0x1700246E RID: 9326
		// (get) Token: 0x0601B7DB RID: 112603 RVA: 0x00878541 File Offset: 0x00876941
		// (set) Token: 0x0601B7DC RID: 112604 RVA: 0x00878549 File Offset: 0x00876949
		public string Extra { get; set; }

		// Token: 0x0601B7DD RID: 112605 RVA: 0x00878552 File Offset: 0x00876952
		public override string ToString()
		{
			return this.ToJsonString();
		}

		// Token: 0x0601B7DE RID: 112606 RVA: 0x0087855C File Offset: 0x0087695C
		public string ToJsonString()
		{
			return JsonMapper.ToJson(new ExtraGifParamInternal
			{
				extra = this.Extra,
				level = this.Level.ToString(),
				vip_level = this.VipLevel.ToString(),
				location = this.Location,
				nickname = this.NickName,
				score = this.Score.ToString(),
				server_area = this.ServerArea
			});
		}

		// Token: 0x0601B7DF RID: 112607 RVA: 0x008785F4 File Offset: 0x008769F4
		public ExtraGifParam ParseFromJsonString(string jsonStr)
		{
			ExtraGifParamInternal extraGifParamInternal = JsonMapper.ToObject<ExtraGifParamInternal>(jsonStr);
			this.Extra = extraGifParamInternal.extra;
			this.Level = int.Parse(extraGifParamInternal.level);
			this.VipLevel = int.Parse(extraGifParamInternal.vip_level);
			this.Location = extraGifParamInternal.location;
			this.NickName = extraGifParamInternal.nickname;
			this.Score = (long)int.Parse(extraGifParamInternal.score);
			this.ServerArea = extraGifParamInternal.server_area;
			return this;
		}
	}
}
