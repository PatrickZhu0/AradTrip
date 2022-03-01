using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020022ED RID: 8941
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node60 : Action
	{
		// Token: 0x06012F53 RID: 77651 RVA: 0x0059A3C4 File Offset: 0x005987C4
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node60()
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
			item.skillID = 1906;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012F54 RID: 77652 RVA: 0x0059A454 File Offset: 0x00598854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C966 RID: 51558
		private List<Input> method_p0;

		// Token: 0x0400C967 RID: 51559
		private bool method_p1;
	}
}
