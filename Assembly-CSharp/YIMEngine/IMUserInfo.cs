using System;
using UnityEngine;

namespace YIMEngine
{
	// Token: 0x02004A4B RID: 19019
	public class IMUserInfo
	{
		// Token: 0x17002476 RID: 9334
		// (get) Token: 0x0601B7F0 RID: 112624 RVA: 0x008786F4 File Offset: 0x00876AF4
		// (set) Token: 0x0601B7F1 RID: 112625 RVA: 0x008786FC File Offset: 0x00876AFC
		public string NickName { get; set; }

		// Token: 0x17002477 RID: 9335
		// (get) Token: 0x0601B7F2 RID: 112626 RVA: 0x00878705 File Offset: 0x00876B05
		// (set) Token: 0x0601B7F3 RID: 112627 RVA: 0x0087870D File Offset: 0x00876B0D
		public string ServerArea { get; set; }

		// Token: 0x17002478 RID: 9336
		// (get) Token: 0x0601B7F4 RID: 112628 RVA: 0x00878716 File Offset: 0x00876B16
		// (set) Token: 0x0601B7F5 RID: 112629 RVA: 0x0087871E File Offset: 0x00876B1E
		public string ServerAreaID { get; set; }

		// Token: 0x17002479 RID: 9337
		// (get) Token: 0x0601B7F6 RID: 112630 RVA: 0x00878727 File Offset: 0x00876B27
		// (set) Token: 0x0601B7F7 RID: 112631 RVA: 0x0087872F File Offset: 0x00876B2F
		public string Location { get; set; }

		// Token: 0x1700247A RID: 9338
		// (get) Token: 0x0601B7F8 RID: 112632 RVA: 0x00878738 File Offset: 0x00876B38
		// (set) Token: 0x0601B7F9 RID: 112633 RVA: 0x00878740 File Offset: 0x00876B40
		public string LocationID { get; set; }

		// Token: 0x1700247B RID: 9339
		// (get) Token: 0x0601B7FA RID: 112634 RVA: 0x00878749 File Offset: 0x00876B49
		// (set) Token: 0x0601B7FB RID: 112635 RVA: 0x00878751 File Offset: 0x00876B51
		public string Platform { get; set; }

		// Token: 0x1700247C RID: 9340
		// (get) Token: 0x0601B7FC RID: 112636 RVA: 0x0087875A File Offset: 0x00876B5A
		// (set) Token: 0x0601B7FD RID: 112637 RVA: 0x00878762 File Offset: 0x00876B62
		public string PlatformID { get; set; }

		// Token: 0x1700247D RID: 9341
		// (get) Token: 0x0601B7FE RID: 112638 RVA: 0x0087876B File Offset: 0x00876B6B
		// (set) Token: 0x0601B7FF RID: 112639 RVA: 0x00878773 File Offset: 0x00876B73
		public int Level { get; set; }

		// Token: 0x1700247E RID: 9342
		// (get) Token: 0x0601B800 RID: 112640 RVA: 0x0087877C File Offset: 0x00876B7C
		// (set) Token: 0x0601B801 RID: 112641 RVA: 0x00878784 File Offset: 0x00876B84
		public int VipLevel { get; set; }

		// Token: 0x1700247F RID: 9343
		// (get) Token: 0x0601B802 RID: 112642 RVA: 0x0087878D File Offset: 0x00876B8D
		// (set) Token: 0x0601B803 RID: 112643 RVA: 0x00878795 File Offset: 0x00876B95
		public string Extra { get; set; }

		// Token: 0x0601B804 RID: 112644 RVA: 0x0087879E File Offset: 0x00876B9E
		public override string ToString()
		{
			return this.ToJsonString();
		}

		// Token: 0x0601B805 RID: 112645 RVA: 0x008787A8 File Offset: 0x00876BA8
		public string ToJsonString()
		{
			return JsonMapper.ToJson(new IMExtraUserInfoInternal
			{
				extra = this.Extra,
				level = this.Level.ToString(),
				vip_level = this.VipLevel.ToString(),
				location = this.Location,
				nickname = this.NickName,
				server_area = this.ServerArea,
				server_area_id = this.ServerAreaID,
				location_id = this.LocationID,
				platform = this.Platform,
				platform_id = this.PlatformID
			});
		}

		// Token: 0x0601B806 RID: 112646 RVA: 0x00878858 File Offset: 0x00876C58
		public IMUserInfo ParseFromJsonString(string jsonStr)
		{
			if (string.IsNullOrEmpty(jsonStr))
			{
				return this;
			}
			try
			{
				IMExtraUserInfoInternal imextraUserInfoInternal = JsonMapper.ToObject<IMExtraUserInfoInternal>(jsonStr);
				this.Extra = imextraUserInfoInternal.extra;
				this.Level = int.Parse(imextraUserInfoInternal.level);
				this.VipLevel = int.Parse(imextraUserInfoInternal.vip_level);
				this.Location = imextraUserInfoInternal.location;
				this.NickName = imextraUserInfoInternal.nickname;
				this.ServerArea = imextraUserInfoInternal.server_area;
				this.LocationID = imextraUserInfoInternal.location_id;
				this.PlatformID = imextraUserInfoInternal.platform_id;
				this.ServerAreaID = imextraUserInfoInternal.server_area_id;
				this.Platform = imextraUserInfoInternal.platform;
			}
			catch (Exception ex)
			{
				Debug.Log(ex.Message);
			}
			return this;
		}
	}
}
