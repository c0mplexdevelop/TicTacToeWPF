Option Strict On

Imports System
Imports System.Windows
Imports System.Windows.Media.Animation

Namespace Animations
    Public Class CornerRadiusAnimation
        Inherits AnimationTimeline

        Public Shared ReadOnly FromProperty As DependencyProperty = DependencyProperty.Register("From", GetType(CornerRadius), GetType(CornerRadiusAnimation))
        Public Shared ReadOnly ToProperty As DependencyProperty = DependencyProperty.Register("To", GetType(CornerRadius), GetType(CornerRadiusAnimation))

        Public Property From As CornerRadius
            Get
                Return CType(GetValue(FromProperty), CornerRadius)
            End Get
            Set(value As CornerRadius)
                SetValue(FromProperty, value)
            End Set
        End Property

        Public Property [To] As CornerRadius
            Get
                Return CType(GetValue(ToProperty), CornerRadius)
            End Get
            Set(value As CornerRadius)
                SetValue(ToProperty, value)
            End Set
        End Property

        Public Overrides ReadOnly Property TargetPropertyType As Type
            Get
                Return GetType(CornerRadius)
            End Get
        End Property

        Protected Overrides Function CreateInstanceCore() As Freezable
            Return New CornerRadiusAnimation()
        End Function

        Public Overrides Function GetCurrentValue(defaultOriginValue As Object, defaultDestinationValue As Object, animationClock As AnimationClock) As Object
            Dim from = Me.From
            Dim [to] = Me.To

            If IsNothing(from) OrElse IsNothing([to]) Then Return MyBase.GetCurrentValue(defaultOriginValue, defaultDestinationValue, animationClock)

            Dim progress = animationClock.CurrentProgress.Value
            Dim topLeft = from.TopLeft + ([to].TopLeft - from.TopLeft) * progress
            Dim topRight = from.TopRight + ([to].TopRight - from.TopRight) * progress
            Dim bottomRight = from.BottomRight + ([to].BottomRight - from.BottomRight) * progress
            Dim bottomLeft = from.BottomLeft + ([to].BottomLeft - from.BottomLeft) * progress

            Return New CornerRadius(topLeft, topRight, bottomRight, bottomLeft)
        End Function
    End Class
End Namespace