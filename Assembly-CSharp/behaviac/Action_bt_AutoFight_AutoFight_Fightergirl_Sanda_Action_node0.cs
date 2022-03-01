using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F3D RID: 7997
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node0 : Action
	{
		// Token: 0x0601281D RID: 75805 RVA: 0x0056A9E8 File Offset: 0x00568DE8
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node0()
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
			item.skillID = 3211;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601281E RID: 75806 RVA: 0x0056AA78 File Offset: 0x00568E78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C215 RID: 49685
		private List<Input> method_p0;

		// Token: 0x0400C216 RID: 49686
		private bool method_p1;
	}
}
