using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02003A1A RID: 14874
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node47 : Action
	{
		// Token: 0x06015BFE RID: 89086 RVA: 0x00691CBC File Offset: 0x006900BC
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node47()
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
			item.skillID = 21164;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x06015BFF RID: 89087 RVA: 0x00691D4C File Offset: 0x0069014C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F515 RID: 62741
		private List<Input> method_p0;

		// Token: 0x0400F516 RID: 62742
		private bool method_p1;
	}
}
