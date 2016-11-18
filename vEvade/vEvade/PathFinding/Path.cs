﻿namespace vEvade.PathFinding
{
    #region

    using System.Collections;
    using System.Collections.Generic;

    #endregion

    public class Path<TNode> : IEnumerable<TNode>
    {
        #region Fields

        public TNode LastStep;

        public Path<TNode> PreviousSteps;

        public double TotalCost;

        #endregion

        #region Constructors and Destructors

        public Path(TNode start)
            : this(start, null, 0)
        {
        }

        private Path(TNode lastStep, Path<TNode> previousSteps, double totalCost)
        {
            this.LastStep = lastStep;
            this.PreviousSteps = previousSteps;
            this.TotalCost = totalCost;
        }

        #endregion

        #region Public Methods and Operators

        public Path<TNode> AddStep(TNode step, double stepCost)
        {
            return new Path<TNode>(step, this, this.TotalCost + stepCost);
        }

        public IEnumerator<TNode> GetEnumerator()
        {
            for (var p = this; p != null; p = p.PreviousSteps)
            {
                yield return p.LastStep;
            }
        }

        #endregion

        #region Explicit Interface Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}