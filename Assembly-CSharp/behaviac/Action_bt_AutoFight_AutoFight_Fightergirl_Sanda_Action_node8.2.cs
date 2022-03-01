using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02001F64 RID: 8036
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node80 : Action
	{
		// Token: 0x0601286B RID: 75883 RVA: 0x0056BAE4 File Offset: 0x00569EE4
		public Action_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node80()
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
			item.skillID = 3006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601286C RID: 75884 RVA: 0x0056BB74 File Offset: 0x00569F74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C267 RID: 49767
		private List<Input> method_p0;

		// Token: 0x0400C268 RID: 49768
		private bool method_p1;
	}
}
