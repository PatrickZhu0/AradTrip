using System;

namespace behaviac
{
	// Token: 0x020036F4 RID: 14068
	public static class bt_Monster_AI_Move_Move_Monster_follow_Move
	{
		// Token: 0x060155FA RID: 87546 RVA: 0x00672D20 File Offset: 0x00671120
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Move/Move_Monster_follow_Move");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node3 condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node = new Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node3();
			condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node.HasEvents());
			Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node4 action_bt_Monster_AI_Move_Move_Monster_follow_Move_node = new Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node4();
			action_bt_Monster_AI_Move_Move_Monster_follow_Move_node.SetClassNameString("Action");
			action_bt_Monster_AI_Move_Move_Monster_follow_Move_node.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Move_Move_Monster_follow_Move_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Move_Move_Monster_follow_Move_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node5 condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node2 = new Condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node5();
			condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.HasEvents());
			Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node6 action_bt_Monster_AI_Move_Move_Monster_follow_Move_node2 = new Action_bt_Monster_AI_Move_Move_Monster_follow_Move_node6();
			action_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Move_Move_Monster_follow_Move_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Move_Move_Monster_follow_Move_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
