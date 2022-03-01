using System;

namespace behaviac
{
	// Token: 0x0200400D RID: 16397
	public static class bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action
	{
		// Token: 0x0601677E RID: 92030 RVA: 0x006CCA78 File Offset: 0x006CAE78
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi/zhaohuanshi_Yijiabeila_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(21);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node22 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node22();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.SetId(22);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node23 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node23();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5.SetId(23);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node5.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node24 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node6 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node24();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node6.SetId(24);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node6.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node25 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node25();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.SetId(25);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(6);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7.SetId(7);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node7.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node8.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9.SetId(9);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node9.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.SetId(10);
			sequence3.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(26);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node27 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node27();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10.SetId(27);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node10.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node28 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node11 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node28();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node11.SetId(28);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node11.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node30 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node30();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.SetId(30);
			sequence4.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
