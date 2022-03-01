using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026E9 RID: 9961
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node73 : Action
	{
		// Token: 0x06013715 RID: 79637 RVA: 0x005C9E1C File Offset: 0x005C821C
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node73()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 0;
			item.randomChangeDirection = false;
			item.skillID = 2003;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013716 RID: 79638 RVA: 0x005C9EAC File Offset: 0x005C82AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D16B RID: 53611
		private List<Input> method_p0;

		// Token: 0x0400D16C RID: 53612
		private bool method_p1;
	}
}
