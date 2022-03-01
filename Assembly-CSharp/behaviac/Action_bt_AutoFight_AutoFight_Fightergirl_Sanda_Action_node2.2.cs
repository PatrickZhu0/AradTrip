using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F52 RID: 8018
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node28 : Action
	{
		// Token: 0x06012847 RID: 75847 RVA: 0x0056B34C File Offset: 0x0056974C
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node28()
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
			item.skillID = 3113;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06012848 RID: 75848 RVA: 0x0056B3DC File Offset: 0x005697DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C241 RID: 49729
		private List<Input> method_p0;

		// Token: 0x0400C242 RID: 49730
		private bool method_p1;
	}
}
