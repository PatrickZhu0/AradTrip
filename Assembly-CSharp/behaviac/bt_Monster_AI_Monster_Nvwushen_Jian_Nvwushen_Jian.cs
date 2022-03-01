using System;

namespace behaviac
{
	// Token: 0x020036E8 RID: 14056
	public static class bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian
	{
		// Token: 0x060155E5 RID: 87525 RVA: 0x006727B4 File Offset: 0x00670BB4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Nvwushen_Jian/Nvwushen_Jian");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node1 condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node = new Condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node1();
			condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.HasEvents());
			Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node3 action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node = new Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node3();
			action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node.HasEvents());
			Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2 action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2 = new Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2();
			action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
