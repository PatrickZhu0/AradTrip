using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F46 RID: 8006
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node44 : Action
	{
		// Token: 0x0601282F RID: 75823 RVA: 0x0056ADC8 File Offset: 0x005691C8
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node44()
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
			item.skillID = 3206;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012830 RID: 75824 RVA: 0x0056AE58 File Offset: 0x00569258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C229 RID: 49705
		private List<Input> method_p0;

		// Token: 0x0400C22A RID: 49706
		private bool method_p1;
	}
}
