using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F28 RID: 7976
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node8 : Action
	{
		// Token: 0x060127F3 RID: 75763 RVA: 0x0056A118 File Offset: 0x00568518
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node8()
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
			item.skillID = 3209;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060127F4 RID: 75764 RVA: 0x0056A1A8 File Offset: 0x005685A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1EB RID: 49643
		private List<Input> method_p0;

		// Token: 0x0400C1EC RID: 49644
		private bool method_p1;
	}
}
