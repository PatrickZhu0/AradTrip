using System;

namespace behaviac
{
	// Token: 0x0200401A RID: 16410
	public static class bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect
	{
		// Token: 0x06016797 RID: 92055 RVA: 0x006CD2C0 File Offset: 0x006CB6C0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi/zhaohuanshi_yijiabeila_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(1);
			selector.AddChild(selector2);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			selector2.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector2.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node9 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node9();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node10 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node10();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.SetId(10);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node2.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector2.HasEvents());
			Selector selector3 = new Selector();
			selector3.SetClassNameString("Selector");
			selector3.SetId(2);
			selector.AddChild(selector3);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector3.AddChild(sequence3);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node12 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node12();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node5.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node13 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node13();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6.SetId(13);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node6.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node14 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node14();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.SetId(14);
			sequence3.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node3.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(15);
			selector3.AddChild(sequence4);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node16 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node16();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7.SetId(16);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node7.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node17 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node17();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8.SetId(17);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node8.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node18 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node18();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.SetId(18);
			sequence4.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node4.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
