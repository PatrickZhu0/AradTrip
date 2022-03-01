using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002602 RID: 9730
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node19 : Action
	{
		// Token: 0x0601354A RID: 79178 RVA: 0x005C0584 File Offset: 0x005BE984
		public Action_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node19()
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
			item.skillID = 1101;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x0601354B RID: 79179 RVA: 0x005C0614 File Offset: 0x005BEA14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF96 RID: 53142
		private List<Input> method_p0;

		// Token: 0x0400CF97 RID: 53143
		private bool method_p1;
	}
}
