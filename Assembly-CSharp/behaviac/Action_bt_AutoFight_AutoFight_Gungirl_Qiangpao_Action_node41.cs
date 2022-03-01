using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200253F RID: 9535
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node41 : Action
	{
		// Token: 0x060133C7 RID: 78791 RVA: 0x005B6E18 File Offset: 0x005B5218
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 2950;
			item.randomChangeDirection = false;
			item.skillID = 2600;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133C8 RID: 78792 RVA: 0x005B6EAC File Offset: 0x005B52AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDED RID: 52717
		private List<Input> method_p0;

		// Token: 0x0400CDEE RID: 52718
		private bool method_p1;
	}
}
