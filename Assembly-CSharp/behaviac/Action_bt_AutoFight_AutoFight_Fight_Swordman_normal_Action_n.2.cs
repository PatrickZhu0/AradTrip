using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002443 RID: 9283
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node22 : Action
	{
		// Token: 0x060131DB RID: 78299 RVA: 0x005ABC5C File Offset: 0x005AA05C
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node22()
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
			item.skillID = 1505;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060131DC RID: 78300 RVA: 0x005ABCEC File Offset: 0x005AA0EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC03 RID: 52227
		private List<Input> method_p0;

		// Token: 0x0400CC04 RID: 52228
		private bool method_p1;
	}
}
