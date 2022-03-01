using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F68 RID: 8040
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node84 : Action
	{
		// Token: 0x06012873 RID: 75891 RVA: 0x0056BC9C File Offset: 0x0056A09C
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node84()
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
			item.skillID = 3007;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012874 RID: 75892 RVA: 0x0056BD2C File Offset: 0x0056A12C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C26F RID: 49775
		private List<Input> method_p0;

		// Token: 0x0400C270 RID: 49776
		private bool method_p1;
	}
}
