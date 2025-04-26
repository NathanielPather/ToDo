<h1>ToDoList Documentation</h1>
<h2>Contributors</h2>
Nathaniel Pather, Sumin Kim

<h2>Setup</h2>

1. Install frontend dependencies
		`cd ToDo.UI`
		`npm install`
2. Run frontend project
		`npm run dev`

<h2>Common Problems</h2>
<details>
<summary>npm ERR! 403 403 Forbidden - GET https://registry.npmjs.org/...</summary>
This issue is most often caused by the proxy setting within a corporate network. Through a standard network the package is usually downloaded directly: 

`localNetwork -> registry.npmjs.org/PACKAGE-NAME`.

 Within a corporate network, a proxy is visited first for security measures, and then redirects to the package:
 `localNetwork -> proxy -> registry.npmjs.org/PACKAGE-NAME`.
 
  In some cases, the proxy can prevent downloading specific packages.

To resolve the proxy issue:
1. Disconnect from the corporate network and use a home wifi connection or mobile hotspot.
2. Ensure the correct registry is set: `npm config set registry https://registry.npmjs.org/`
3. Set the strict ssl to false: `npm config delete strict-ssl`
4. Delete all proxy settings: `npm config delete proxy` and `npm config delete https-proxy`
5. Confirm the proxy settings are removed: `%HTTP_PROXY%` and `%HTTPS_PROXY%`and `npm config get proxy`
</details>

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

<details>
<summary>package.json versus package-lock.json</summary>
package.json is a general criteria of the dependencies of the project. A wide range of versions can be used, such as any 6.*. package-lock.json however locks the project to specific versions. To ensure consistent use, any changes to package.json and package-lock.json should be commited.
</details>