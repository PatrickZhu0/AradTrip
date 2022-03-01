using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001E9F RID: 7839
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_node73 : Action
	{
		// Token: 0x060126E8 RID: 75496 RVA: 0x00563C20 File Offset: 0x00562020
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_node73()
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
			item.skillID = 9744;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060126E9 RID: 75497 RVA: 0x00563CB0 File Offset: 0x005620B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0D5 RID: 49365
		private List<Input> method_p0;

		// Token: 0x0400C0D6 RID: 49366
		private bool method_p1;
	}
}
