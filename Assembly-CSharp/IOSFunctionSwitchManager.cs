using System;
using Protocol;
using ProtoTable;

// Token: 0x0200173F RID: 5951
public class IOSFunctionSwitchManager : Singleton<IOSFunctionSwitchManager>
{
	// Token: 0x0600E9D8 RID: 59864 RVA: 0x003DEED4 File Offset: 0x003DD2D4
	public override void Init()
	{
		this.iosFuncSwitchTypes = null;
	}

	// Token: 0x0600E9D9 RID: 59865 RVA: 0x003DEEDD File Offset: 0x003DD2DD
	public override void UnInit()
	{
		if (this.iosFuncSwitchTypes != null)
		{
			this.iosFuncSwitchTypes = null;
		}
	}

	// Token: 0x0600E9DA RID: 59866 RVA: 0x003DEEF4 File Offset: 0x003DD2F4
	public void AddClosedFunctions(GateNotifySysSwitch msg)
	{
		SysSwitchCfg[] cfg = msg.cfg;
		if (cfg != null)
		{
			this.iosFuncSwitchTypes = new IOSFuncSwitchTable.eType[cfg.Length];
			if (this.iosFuncSwitchTypes == null)
			{
				return;
			}
			for (int i = 0; i < cfg.Length; i++)
			{
				SysSwitchCfg sysSwitchCfg = cfg[i];
				if (sysSwitchCfg.switchValue == 0)
				{
					this.iosFuncSwitchTypes[i] = (IOSFuncSwitchTable.eType)sysSwitchCfg.sysType;
				}
			}
		}
	}

	// Token: 0x0600E9DB RID: 59867 RVA: 0x003DEF5C File Offset: 0x003DD35C
	public bool IsFunctionClosed(IOSFuncSwitchTable.eType funcType)
	{
		bool result = false;
		if (this.iosFuncSwitchTypes == null)
		{
			return false;
		}
		for (int i = this.firstIndex; i < this.iosFuncSwitchTypes.Length; i++)
		{
			IOSFuncSwitchTable.eType eType = this.iosFuncSwitchTypes[i];
			if (eType == funcType)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x04008DD0 RID: 36304
	private int firstIndex;

	// Token: 0x04008DD1 RID: 36305
	private IOSFuncSwitchTable.eType[] iosFuncSwitchTypes;
}
