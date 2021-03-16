using System;


namespace SimpleCalculator
{
    public interface IItem
    {
        int Value { get; }
    }
    
    public sealed class IntegerItem : IItem
    {
        private int value;

        public IntegerItem(int value)
        {
            this.value = value;
        }

        public int Value { get => value; }

        public override bool Equals(object obj)
        {
            var other = obj as IntegerItem;
            return other != null && this.value == other.value;
        }
        
        public override int GetHashCode()
        {
            return value;
        }
    }

    public sealed class AddItem : IItem
    {
        private IItem first;
        private IItem second;

        public AddItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value + second.Value; }

        public override bool Equals(object obj)
        {
            var other = obj as AddItem;
            return other != null && this.first.Equals(other.first) && this.second.Equals(other.second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }

    public sealed class SubItem : IItem
    {
        private IItem first;
        private IItem second;

        public SubItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value - second.Value; }

        public override bool Equals(object obj)
        {
            var other = obj as SubItem;
            return other != null && this.first.Equals(other.first) && this.second.Equals(other.second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }

    public sealed class MulItem : IItem
    {
        private IItem first;
        private IItem second;

        public MulItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value * second.Value; }

        public override bool Equals(object obj)
        {
            var other = obj as MulItem;
            return other != null && this.first.Equals(other.first) && this.second.Equals(other.second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }
}