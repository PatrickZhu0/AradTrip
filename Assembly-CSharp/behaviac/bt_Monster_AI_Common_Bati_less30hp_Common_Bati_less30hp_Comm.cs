using System;

namespace behaviac
{
	// Token: 0x02003237 RID: 12855
	public static class bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp
	{
		// Token: 0x06014CF1 RID: 85233 RVA: 0x00645030 File Offset: 0x00643430
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Common_Bati_less30hp/Common_Bati_less30hp_Common_Bati_less30hp");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			DecoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node1 decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node = new DecoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node1();
			decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetClassNameString("DecoratorAlwaysSuccess");
			decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetId(1);
			sequence.AddChild(decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node);
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(2);
			decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node4 condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node = new Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node4();
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.HasEvents());
			Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node5 action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node = new Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node5();
			action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetClassNameString("Action");
			action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.SetHasEvents(decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.HasEvents() | selector.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | decoratorAlwaysSuccess_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
