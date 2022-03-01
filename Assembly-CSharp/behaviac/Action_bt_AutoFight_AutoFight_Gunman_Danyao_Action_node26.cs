using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020025BC RID: 9660
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node26 : Action
	{
		// Token: 0x060134BF RID: 79039 RVA: 0x005BCC24 File Offset: 0x005BB024
		public Action_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node26()
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
			item.skillID = 1303;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060134C0 RID: 79040 RVA: 0x005BCCB4 File Offset: 0x005BB0B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEFB RID: 52987
		private List<Input> method_p0;

		// Token: 0x0400CEFC RID: 52988
		private bool method_p1;
	}
}
