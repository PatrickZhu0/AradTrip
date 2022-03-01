using System;
using GameClient;
using ProtoTable;

// Token: 0x02000FFE RID: 4094
public class ComNewbieGuideTalkDialog : ComNewbieGuideBase
{
	// Token: 0x06009BC6 RID: 39878 RVA: 0x001E6284 File Offset: 0x001E4684
	public override void StartInit(params object[] args)
	{
		base.StartInit(args);
		this.id = -1;
		this.mTryPauseBattle = true;
		if (args != null)
		{
			if (args.Length >= 1)
			{
				this.id = (int)args[0];
			}
			if (args.Length >= 2 && (eNewbieGuideAgrsName)args[1] == eNewbieGuideAgrsName.SaveBoot)
			{
				this.mSendSaveBoot = true;
			}
			if (args.Length >= 3 && (eNewbieGuideAgrsName)args[2] == eNewbieGuideAgrsName.PauseBattle)
			{
				this.mTryPauseBattle = true;
			}
		}
	}

	// Token: 0x06009BC7 RID: 39879 RVA: 0x001E6300 File Offset: 0x001E4700
	protected override ComNewbieGuideBase.GuideState _init()
	{
		if (this.id <= 0)
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		if (Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(this.id, string.Empty, string.Empty) == null)
		{
		}
		if (!base.AddDialog(this.id, null))
		{
			return ComNewbieGuideBase.GuideState.Exception;
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}

	// Token: 0x04005529 RID: 21801
	public int id;
}
