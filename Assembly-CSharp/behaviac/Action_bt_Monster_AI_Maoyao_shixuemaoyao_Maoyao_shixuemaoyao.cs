using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020035BF RID: 13759
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node9 : Action
	{
		// Token: 0x060153A9 RID: 86953 RVA: 0x00666158 File Offset: 0x00664558
		public Action_bt_Monster_AI_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_Maoyao_shixuemaoyao_node9()
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
			item.skillID = 5038;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060153AA RID: 86954 RVA: 0x006661E8 File Offset: 0x006645E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED70 RID: 60784
		private List<Input> method_p0;

		// Token: 0x0400ED71 RID: 60785
		private bool method_p1;
	}
}
