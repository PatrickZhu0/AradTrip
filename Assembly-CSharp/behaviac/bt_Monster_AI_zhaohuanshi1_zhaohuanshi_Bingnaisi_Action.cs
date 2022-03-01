using System;

namespace behaviac
{
	// Token: 0x0200402E RID: 16430
	public static class bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action
	{
		// Token: 0x060167BD RID: 92093 RVA: 0x006CE02C File Offset: 0x006CC42C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/zhaohuanshi1/zhaohuanshi_Bingnaisi_Action");
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
			sequence.SetId(3);
			selector2.AddChild(sequence);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.SetId(9);
			sequence.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector2.AddChild(sequence2);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node10 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node4 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node10();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node4.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node4.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node11 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node5 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node11();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node5.SetId(11);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node5.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node12 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node12();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6.SetId(12);
			sequence2.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node6.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node13 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2 = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node13();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.SetId(13);
			sequence2.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node2.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector2.HasEvents());
			Selector selector3 = new Selector();
			selector3.SetClassNameString("Selector");
			selector3.SetId(2);
			selector.AddChild(selector3);
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			selector3.AddChild(sequence3);
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node14 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node14();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7.SetId(14);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node7.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node15 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node15();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8.SetId(15);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node8.HasEvents());
			Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node16 condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9 = new Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node16();
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9.SetId(16);
			sequence3.AddChild(condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node9.HasEvents());
			Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node17 action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3 = new Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node17();
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.SetId(17);
			sequence3.AddChild(action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node3.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | selector3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
