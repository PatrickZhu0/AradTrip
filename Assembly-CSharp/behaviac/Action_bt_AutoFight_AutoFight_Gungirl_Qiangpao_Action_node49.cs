using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200251B RID: 9499
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node49 : Action
	{
		// Token: 0x0601337F RID: 78719 RVA: 0x005B5E68 File Offset: 0x005B4268
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node49()
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
			item.skillID = 2602;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013380 RID: 78720 RVA: 0x005B5EF8 File Offset: 0x005B42F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA1 RID: 52641
		private List<Input> method_p0;

		// Token: 0x0400CDA2 RID: 52642
		private bool method_p1;
	}
}
