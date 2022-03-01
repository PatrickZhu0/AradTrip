using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020026F1 RID: 9969
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node14 : Action
	{
		// Token: 0x06013725 RID: 79653 RVA: 0x005CA184 File Offset: 0x005C8584
		public Action_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node14()
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
			item.skillID = 2009;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06013726 RID: 79654 RVA: 0x005CA214 File Offset: 0x005C8614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D17B RID: 53627
		private List<Input> method_p0;

		// Token: 0x0400D17C RID: 53628
		private bool method_p1;
	}
}
