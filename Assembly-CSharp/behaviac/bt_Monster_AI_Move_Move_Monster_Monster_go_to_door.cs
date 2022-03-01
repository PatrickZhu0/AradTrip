using System;

namespace behaviac
{
	// Token: 0x020036F6 RID: 14070
	public static class bt_Monster_AI_Move_Move_Monster_Monster_go_to_door
	{
		// Token: 0x060155FD RID: 87549 RVA: 0x00672EF0 File Offset: 0x006712F0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Move/Move_Monster_Monster_go_to_door");
			bt.IsFSM = false;
			Action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node0 action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node = new Action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node0();
			action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node.SetClassNameString("Action");
			action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node.SetId(0);
			bt.AddChild(action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node);
			bt.SetHasEvents(bt.HasEvents() | action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node.HasEvents());
			return true;
		}
	}
}
