using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F60 RID: 8032
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node74 : Action
	{
		// Token: 0x06012863 RID: 75875 RVA: 0x0056B92C File Offset: 0x00569D2C
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node74()
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
			item.skillID = 3005;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012864 RID: 75876 RVA: 0x0056B9BC File Offset: 0x00569DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C25F RID: 49759
		private List<Input> method_p0;

		// Token: 0x0400C260 RID: 49760
		private bool method_p1;
	}
}
