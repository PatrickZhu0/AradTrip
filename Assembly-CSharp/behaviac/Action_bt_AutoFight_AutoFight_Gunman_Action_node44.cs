using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002589 RID: 9609
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Action_node44 : Action
	{
		// Token: 0x0601345A RID: 78938 RVA: 0x005BA864 File Offset: 0x005B8C64
		public Action_bt_AutoFight_AutoFight_Gunman_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 200;
			item.randomChangeDirection = false;
			item.skillID = 1200;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601345B RID: 78939 RVA: 0x005BA8F8 File Offset: 0x005B8CF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE83 RID: 52867
		private List<Input> method_p0;

		// Token: 0x0400CE84 RID: 52868
		private bool method_p1;
	}
}
