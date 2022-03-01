using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002634 RID: 9780
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node40 : Action
	{
		// Token: 0x060135AE RID: 79278 RVA: 0x005C1BE4 File Offset: 0x005BFFE4
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node40()
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
			item.skillID = 1006;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060135AF RID: 79279 RVA: 0x005C1C74 File Offset: 0x005C0074
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFFC RID: 53244
		private List<Input> method_p0;

		// Token: 0x0400CFFD RID: 53245
		private bool method_p1;
	}
}
