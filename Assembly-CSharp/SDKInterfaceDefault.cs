using System;
using UnityEngine;

// Token: 0x02004666 RID: 18022
public class SDKInterfaceDefault : SDKInterface
{
	// Token: 0x06019650 RID: 104016 RVA: 0x00807356 File Offset: 0x00805756
	public override string GetClipboardText()
	{
		return GUIUtility.systemCopyBuffer;
	}

	// Token: 0x06019651 RID: 104017 RVA: 0x0080735D File Offset: 0x0080575D
	public override int TryGetCurrVersionAPI()
	{
		return 1000;
	}

	// Token: 0x06019652 RID: 104018 RVA: 0x00807364 File Offset: 0x00805764
	public override bool NeedSDKBindPhoneOpen()
	{
		return true;
	}

	// Token: 0x06019653 RID: 104019 RVA: 0x00807367 File Offset: 0x00805767
	public override bool IsOppoPlatform()
	{
		return Global.Settings.mainSDKChannel == SDKChannel.OPPO;
	}

	// Token: 0x06019654 RID: 104020 RVA: 0x00807381 File Offset: 0x00805781
	public override bool IsVivoPlatForm()
	{
		return Global.Settings.mainSDKChannel == SDKChannel.VIVO;
	}

	// Token: 0x06019655 RID: 104021 RVA: 0x0080739B File Offset: 0x0080579B
	public override bool IsStartFromGameCenter()
	{
		return Global.Settings.mainSDKChannel == SDKChannel.VIVO || Global.Settings.mainSDKChannel == SDKChannel.OPPO;
	}

	// Token: 0x06019656 RID: 104022 RVA: 0x008073C6 File Offset: 0x008057C6
	public override bool RequestAudioAuthorization()
	{
		return true;
	}

	// Token: 0x06019657 RID: 104023 RVA: 0x008073C9 File Offset: 0x008057C9
	public override string GetBuildPlatformId()
	{
		return TR.Value("zymg_plat_id_ios");
	}

	// Token: 0x06019658 RID: 104024 RVA: 0x008073D5 File Offset: 0x008057D5
	public override string GetOnlineServicePlatformId()
	{
		return TR.Value("zymg_onlineservice_plat_id_other");
	}

	// Token: 0x06019659 RID: 104025 RVA: 0x008073E1 File Offset: 0x008057E1
	public override string GetOnlineServicePlatformName()
	{
		return TR.Value("zymg_onlineservice_plat_name_other");
	}
}
