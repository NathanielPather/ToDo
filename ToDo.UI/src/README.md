<h1>ToDoList Documentation</h1>
<h2>Contributors</h2>
Nathaniel Pather

<h2>Implementation Decisions</h2>
<details>
<summary>UseEffect Usage</summary>
Inside the useEffect we call the async fetch, then we set the state inside the useEffect. The loadLists constant is just the definition of this logic. We call loadLists inside the useEffect.

<h5>What is the empty array at the end?</h5>
The empty array is called a dependency array. It means run this useEffect only once (after the first render), then never again.

<h5>So the dependency array is what the useEffect is dependent on?</h5>
Yes, if we specify [lists] in the dependency array, the useEffect will run every time lists changes.

<h5>Why do we need to use a useState inside a useEffect?</h5>
We declare useState outside, but set the state inside. Fetching data is considered side effect logic (happens after render). The useEffect hook is how we handle sideEffects in react. Once data is fetched, the component updates with that data.

<h5>Are all fetches considered side effects?</h5>
Because technically we can fetch, **THEN** render?
Yes, all fetches are side effects as the render must remain pure and independent of all fetches.

<h5>Despite including lists in the dependency array, infinite fetching occurs,
why?</h5>
In JavaScript arrays are reference types. Despite being identential, if a new array is created, it's considered different.

```ts
// ToDo\ToDo.UI\src\app\components\ToDoLists.tsx
useEffect(() => {
	const loadLists = async () => {
		const data = await GetLists();
		setLists(data);
	};

	loadLists();
}, []);
```
</details>