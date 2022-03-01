using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200219D RID: 8605
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node45 : Action
	{
		// Token: 0x06012CCA RID: 77002 RVA: 0x005873D4 File Offset: 0x005857D4
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node45()
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
			item.skillID = 1204;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012CCB RID: 77003 RVA: 0x00587464 File Offset: 0x00585864
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6BD RID: 50877
		private List<Input> method_p0;

		// Token: 0x0400C6BE RID: 50878
		private bool method_p1;
	}
}
