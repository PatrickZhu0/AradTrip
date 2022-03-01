using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200252F RID: 9519
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node75 : Action
	{
		// Token: 0x060133A7 RID: 78759 RVA: 0x005B66EC File Offset: 0x005B4AEC
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node75()
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
			item.skillID = 2612;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133A8 RID: 78760 RVA: 0x005B677C File Offset: 0x005B4B7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDC9 RID: 52681
		private List<Input> method_p0;

		// Token: 0x0400CDCA RID: 52682
		private bool method_p1;
	}
}
