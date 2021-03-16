using System;


namespace SimpleCalculator
{
    interface IItem
    {
        int Value { get; }
    }
    
    sealed class IntegerItem : IItem
    {
        private int value;

        public IntegerItem(int value)
        {
            this.value = value;
        }

        public int Value { get => value; }

        public static bool operator==(IntegerItem left, IItem right)
        {
            return left != null && left.Equals(right);
        }

        public static bool operator!=(IntegerItem left, IItem right)
        {
            return !(left == right);
        }

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

    sealed class AddItem : IItem
    {
        private IItem first;
        private IItem second;

        public AddItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value + second.Value; }

        public static bool operator==(AddItem left, IItem right)
        {
            return left != null && left.Equals(right);
        }

        public static bool operator!=(AddItem left, IItem right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var other = obj as AddItem;
            return other != null && this.first == other.first && this.second == other.second;
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }

    sealed class SubItem : IItem
    {
        private IItem first;
        private IItem second;

        public SubItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value - second.Value; }

        public static bool operator==(SubItem left, IItem right)
        {
            return left != null && left.Equals(right);
        }

        public static bool operator!=(SubItem left, IItem right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var other = obj as SubItem;
            return other != null && this.first == other.first && this.second == other.second;
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }

    sealed class MulItem : IItem
    {
        private IItem first;
        private IItem second;

        public MulItem(IItem first, IItem second)
        {
            this.first = first;
            this.second = second;
        }

        public int Value { get => first.Value * second.Value; }

        public static bool operator==(MulItem left, IItem right)
        {
            return left != null && left.Equals(right);
        }

        public static bool operator!=(MulItem left, IItem right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var other = obj as MulItem;
            return other != null && this.first == other.first && this.second == other.second;
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() ^ second.GetHashCode();
        }
    }
}