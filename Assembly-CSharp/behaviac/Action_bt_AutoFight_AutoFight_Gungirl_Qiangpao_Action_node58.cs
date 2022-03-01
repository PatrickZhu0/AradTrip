using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002527 RID: 9511
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node58 : Action
	{
		// Token: 0x06013397 RID: 78743 RVA: 0x005B6384 File Offset: 0x005B4784
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node58()
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
			item.skillID = 2608;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013398 RID: 78744 RVA: 0x005B6414 File Offset: 0x005B4814
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDB9 RID: 52665
		private List<Input> method_p0;

		// Token: 0x0400CDBA RID: 52666
		private bool method_p1;
	}
}
