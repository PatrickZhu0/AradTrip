using System;

namespace behaviac
{
	// Token: 0x02003FDC RID: 16348
	public static class bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action
	{
		// Token: 0x06016720 RID: 91936 RVA: 0x006CA9E0 File Offset: 0x006C8DE0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi/zhaohuanshi_Luyisi_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.SetId(9);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.SetId(10);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node12 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node12();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.SetId(12);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node13 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node5 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node13();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node5.SetId(13);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node5.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node14 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node14();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6.SetId(14);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node15 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node15();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.SetId(15);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(16);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node17 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node17();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7.SetId(17);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node18 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node18();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8.SetId(18);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node8.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node19 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node19();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9.SetId(19);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node9.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node20 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node20();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.SetId(20);
			sequence3.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(3);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node6();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10.SetId(6);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node10.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4 condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11 = new Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4();
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11.SetId(4);
			sequence4.AddChild(condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node11.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7 action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4 = new Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node7();
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.SetId(7);
			sequence4.AddChild(action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
