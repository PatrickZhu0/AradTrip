using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200253B RID: 9531
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node37 : Action
	{
		// Token: 0x060133BF RID: 78783 RVA: 0x005B6C60 File Offset: 0x005B5060
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 2850;
			item.randomChangeDirection = false;
			item.skillID = 2605;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133C0 RID: 78784 RVA: 0x005B6CF4 File Offset: 0x005B50F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDE5 RID: 52709
		private List<Input> method_p0;

		// Token: 0x0400CDE6 RID: 52710
		private bool method_p1;
	}
}
