using System;
using System.Collections.Generic;

// Token: 0x02004111 RID: 16657
public class BeAICommandPoolImp : IObjectPool
{
	// Token: 0x06016ACF RID: 92879 RVA: 0x006DFB95 File Offset: 0x006DDF95
	public string GetPoolName()
	{
		return this.poolName;
	}

	// Token: 0x06016AD0 RID: 92880 RVA: 0x006DFB9D File Offset: 0x006DDF9D
	public string GetPoolInfo()
	{
		return string.Format("{0}/{1}", this.remainInst, this.totalInst);
	}

	// Token: 0x06016AD1 RID: 92881 RVA: 0x006DFBBF File Offset: 0x006DDFBF
	public string GetPoolDetailInfo()
	{
		return "detailInfo";
	}

	// Token: 0x06016AD2 RID: 92882 RVA: 0x006DFBC6 File Offset: 0x006DDFC6
	public void Init()
	{
		Singleton<CPoolManager>.GetInstance().RegisterPool(this.poolKey, this);
	}

	// Token: 0x06016AD3 RID: 92883 RVA: 0x006DFBDC File Offset: 0x006DDFDC
	public BeAICommand GetAICommand(AI_COMMAND cmdType, BeEntity e)
	{
		BeAICommand beAICommand = null;
		if (!this.commandPool.ContainsKey((int)cmdType))
		{
			this.commandPool.Add((int)cmdType, new List<BeAICommand>());
		}
		List<BeAICommand> list = this.commandPool[(int)cmdType];
		if (list.Count > 0)
		{
			beAICommand = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		else
		{
			this.newCount++;
			this.totalInst++;
			switch (cmdType)
			{
			case AI_COMMAND.WALK:
				beAICommand = new BeAIWalkCommand(e);
				break;
			case AI_COMMAND.IDLE:
				beAICommand = new BeAIIdleCommand(e);
				break;
			case AI_COMMAND.ATTACK:
				beAICommand = new BeAIAttackCommand(e);
				break;
			case AI_COMMAND.SKILL:
				beAICommand = new BeAISkillCommand(e);
				break;
			case AI_COMMAND.NONE:
				beAICommand = new BeAINoneCommand(e);
				break;
			}
		}
		beAICommand.Reset(e);
		return beAICommand;
	}

	// Token: 0x06016AD4 RID: 92884 RVA: 0x006DFCD0 File Offset: 0x006DE0D0
	public void PutAICommand(BeAICommand cmd)
	{
		if (!this.commandPool.ContainsKey((int)cmd.cmdType))
		{
			return;
		}
		if (this.commandPool[(int)cmd.cmdType].Contains(cmd))
		{
			return;
		}
		this.remainInst++;
		this.commandPool[(int)cmd.cmdType].Add(cmd);
	}

	// Token: 0x06016AD5 RID: 92885 RVA: 0x006DFD36 File Offset: 0x006DE136
	public void Clear()
	{
		this.commandPool.Clear();
		this.totalInst = 0;
		this.remainInst = 0;
	}

	// Token: 0x06016AD6 RID: 92886 RVA: 0x006DFD54 File Offset: 0x006DE154
	public void DebugPrint(string pre)
	{
		string text = pre + "\n";
		foreach (KeyValuePair<int, List<BeAICommand>> keyValuePair in this.commandPool)
		{
			text += string.Format("{0}:{1}\n", keyValuePair.Key, keyValuePair.Value.Count);
		}
		Logger.LogErrorFormat(text, new object[0]);
	}

	// Token: 0x040102B9 RID: 66233
	private Dictionary<int, List<BeAICommand>> commandPool = new Dictionary<int, List<BeAICommand>>();

	// Token: 0x040102BA RID: 66234
	private int newCount;

	// Token: 0x040102BB RID: 66235
	private string poolKey = "BeAICommandPool";

	// Token: 0x040102BC RID: 66236
	private string poolName = "AICommand池";

	// Token: 0x040102BD RID: 66237
	private int totalInst;

	// Token: 0x040102BE RID: 66238
	private int remainInst;
}
